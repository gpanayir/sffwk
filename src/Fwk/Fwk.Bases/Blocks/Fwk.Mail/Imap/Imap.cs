using System;
using System.Collections;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using Fwk.Mail.Common;


namespace Fwk.Mail.Imap
{
	/// <summary>
	/// Imap class implementes IMAP client API
	/// </summary>
	sealed class Imap :  ImapBase
    {
        // Singleton
        private Imap() { }
        public static readonly Imap Instance;

        static Imap()
        {
            Instance = new Imap();
        }

        #region [CONST]

        /// <summary>
		/// If user has logged in to his mailbox.
		/// </summary>
		bool   m_bIsLoggedIn = false;
		/// <summary>
		/// Mailbox (Folder) name. Default INBOX.
		/// </summary>
		string m_sMailboxName = "INBOX";
		/// <summary>
		/// If folder is selected.
		/// </summary>
		bool   m_bIsFolderSelected = false;
		/// <summary>
		/// if folder is examined.
		/// </summary>
		bool   m_bIsFolderExamined = false;
		/// <summary>
		/// Total number of messages in mailbox.
		/// </summary>
		int    m_nTotalMessages = 0;
		/// <summary>
		/// Number of recent messages in mailbox.
		/// </summary>
		int    m_nRecentMessages = 0;
		/// <summary>
		/// First unseen message UID
		/// </summary>
		int    m_nFirstUnSeenMsgUID = -1;

        #endregion

        #region [LOGIN]

        /// <summary>
        ///  Login to specified Imap host and default port (143)
        /// </summary>
        /// <param name="sHost">Imap Server name</param>
        /// <param name="sUserId">User's login id</param>
        /// <param name="sPassword">User's password</param>
		public LoginResponseEnum Login (string sHost, string sUserId, string sPassword, bool useSSL)
		{
            LoginResponseEnum wResultadoLogin;

            m_useSSL = useSSL;
            
            try 
			{
				wResultadoLogin = Login(sHost, useSSL ? IMAP_DEFAULT_SSL_PORT : IMAP_DEFAULT_PORT, sUserId, sPassword,useSSL);

                return wResultadoLogin;
            }
			catch(Exception e)
			{
				throw e;
			}
		}

        /// <summary>
        /// Login to specified Imap host and port
        /// </summary>
        /// <param name="sHost">Imap server name</param>
        /// <param name="nPort">Imap server port</param>
        /// <param name="sUserId">User's login id</param>
        /// <param name="sPassword">User's password</param>
        /// <exception cref="IMAP_ERR_LOGIN"
        /// <exception cref="IMAP_ERR_INVALIDPARAM"
		public LoginResponseEnum Login(string sHost, ushort nPort, string sUserId, string sPassword, bool useSSL ) 
		{
            m_useSSL = useSSL;
            
            ImapResponseEnum eImapResponse = ImapResponseEnum.IMAP_SUCCESS_RESPONSE;			
			ImapException e_invalidparam = new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_INVALIDPARAM);
			
            #region [Validaciones]

			if (sHost.Length == 0) 
			{
				//Log (LogTypeEnum.ERROR, "Invalid m_sHost name");
				throw e_invalidparam;
			}

			if (sUserId.Length == 0)
			{
				//Log (LogTypeEnum.ERROR, "Invalid m_sUserId");
				throw e_invalidparam;
			}

			if (sPassword.Length == 0)
			{
				//Log (LogTypeEnum.ERROR, "Invalid Password");
				throw e_invalidparam;
			}

            #endregion

            // Se verifica si el usuario ya se encuentra conectado
			if (m_bIsConnected) 
			{
				if (m_bIsLoggedIn)
				{
					if (m_sHost == sHost && m_nPort == nPort)
					{
						if (m_sUserId == sUserId && m_sPassword == sPassword ) 
						{
                            return LoginResponseEnum.USER_ALREADY_CONNECT;
						}
						else
							LogOut();
					}
					else Disconnect();
				}
			}
				
			m_bIsConnected = false;
			m_bIsLoggedIn = false;
			
            // Se lleva a cabo la conexi�n
			try 
			{
				eImapResponse = Connect(sHost, nPort, useSSL);
				if (eImapResponse == ImapResponseEnum.IMAP_SUCCESS_RESPONSE)
				{
					m_bIsConnected = true;
				}
				else return LoginResponseEnum.CONNECTION_FAIL;
			}
			catch (Exception e)
			{
				throw e;
			}
			
            // Si la conexi�n se llevo a cabo con exito, se procede a hacer el login
            List<String> asResultArray = new List<String>();
			string sCommand = IMAP_LOGIN_COMMAND;
			sCommand += String.Format(" {0} {1}", sUserId, sPassword);
			sCommand += IMAP_COMMAND_EOL;
			try
			{
				eImapResponse = SendAndReceive(sCommand, ref asResultArray);
				if (eImapResponse == ImapResponseEnum.IMAP_SUCCESS_RESPONSE)
				{
					m_bIsLoggedIn = true;
					m_sUserId = sUserId;
					m_sPassword = sPassword;
				}
				else return LoginResponseEnum.LOGIN_FAIL;
				
			}
			catch (Exception e)
			{
				throw e;
			}

            return LoginResponseEnum.LOGIN_SUCCESS;

		}

        /// <summary>
        /// Logout the user: It logout the user and disconnect the connetion from IMAP server.
        /// </summary>
        public LoginResponseEnum LogOut() 
		{
            ImapResponseEnum eImapResponse;
            LoginResponseEnum wResult = LoginResponseEnum.DISCONNECTION_FAIL;

			if (m_bIsLoggedIn)
			{				
                List<String> asResultArray = new List<String>();
				string sCommand = IMAP_LOGOUT_COMMAND;
				sCommand += IMAP_COMMAND_EOL;

				try
				{
					eImapResponse = SendAndReceive(sCommand, ref asResultArray);

                    switch (eImapResponse)
                    {
                        case ImapResponseEnum.IMAP_SUCCESS_RESPONSE:
                            wResult = LoginResponseEnum.DISCONNECTION_SUCCESS;
                            break;
                        case ImapResponseEnum.IMAP_FAILURE_RESPONSE:
                            wResult = LoginResponseEnum.DISCONNECTION_FAIL;
                            break;                        
                        default:
                            wResult = LoginResponseEnum.DISCONNECTION_FAIL;
                            break;
                    }

                    Disconnect();
                    m_bIsLoggedIn = false;                   

				}
				catch (Exception)
				{
					Disconnect();
					m_bIsLoggedIn = false;
                    return LoginResponseEnum.DISCONNECTION_FAIL;
				}
			}
            return wResult;
        }

        /// <summary>
        /// Get the status mailbox
        /// </summary>
        /// <returns></returns>
        public List<String> GetStatus()
        {

            ImapResponseEnum eImapResponse = ImapResponseEnum.IMAP_SUCCESS_RESPONSE;
            List<String> asResultArray = new List<String>();

            String sCommand = "status INBOX (unseen)";
            
            sCommand += IMAP_COMMAND_EOL;

            try
            {
                eImapResponse = SendAndReceive(sCommand, ref asResultArray);
                if (eImapResponse == ImapResponseEnum.IMAP_SUCCESS_RESPONSE)
                {
                    m_sMailboxName = "INBOX";
                    m_bIsFolderExamined = true;
                }


                return asResultArray;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
        
        #region [FOLDERS]

        /// <summary>
        /// Select the sFolder/mailbox after login
        /// </summary>
        /// <param name="sFolder">mailbox folder</param>
        /// <exception cref="IMAP_ERR_SELECT"
        /// <exception cref="IMAP_ERR_INSUFFICIENT_DATA"
        /// <exception cref="IMAP_ERR_INVALIDPARAM"
		public void SelectFolder(string sFolder) 
		{
			if (!m_bIsLoggedIn)
			{
				try
				{
					Restore(false, m_useSSL);
				}
				catch (ImapException e)
				{
					if (e.Type!= ImapException.ImapErrorEnum.IMAP_ERR_INSUFFICIENT_DATA)
						throw e;
					throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_NOTCONNECTED,e.Message);	}
				
			}

			ImapResponseEnum eImapResponse = ImapResponseEnum.IMAP_SUCCESS_RESPONSE;
			ImapException e_select   = new ImapException (ImapException.ImapErrorEnum.IMAP_ERR_SELECT, sFolder);
			ImapException e_invalidparam = new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_INVALIDPARAM);

			if (sFolder.Length == 0)
			{
				throw e_invalidparam;
			}
			if (m_bIsFolderSelected)
			{
				if (m_sMailboxName == sFolder)
					return;
				
				else m_bIsFolderSelected = false;
			}
            
            List<String> asResultArray = new List<String>();
			string sCommand = IMAP_SELECT_COMMAND;
			sCommand += " " + sFolder +IMAP_COMMAND_EOL;
			
            try
			{
				eImapResponse = SendAndReceive(sCommand, ref asResultArray);
				if (eImapResponse == ImapResponseEnum.IMAP_SUCCESS_RESPONSE)
				{
					m_sMailboxName = sFolder;
					m_bIsFolderSelected = true;
				}
				else throw e_select;
			}
			catch (Exception e)
			{
				throw e;
			}

			//-------------------------
			// PARSE RESPONSE

			bool bResult = false;
			foreach (string sLine in  asResultArray) 
			{
				// If this is an unsolicited response starting with '*'
				if (sLine.IndexOf(IMAP_UNTAGGED_RESPONSE_PREFIX) != -1) 
				{
					// parse the line by space
					string [] asTokens;
					asTokens = sLine.Split(' ');
					if (asTokens[2] == "EXISTS") 
					{
						// The line will look like "* 2 EXISTS"
						m_nTotalMessages = Convert.ToInt32(asTokens[1]);
					}
					else if (asTokens[2] == "RECENT") 
					{
						// The line will look like "* 2 RECENT"
						m_nRecentMessages = Convert.ToInt32(asTokens[1]);
					}
					else if (asTokens[2] == "[UNSEEN") 
					{
						// The line will look like "* OK [UNSEEN 2]"
						string sUIDPart = asTokens[3].Substring(0, asTokens[3].Length-1);
						m_nFirstUnSeenMsgUID = Convert.ToInt32(sUIDPart);
					}
				}
					// If this line looks like "<command-tag> OK ..."
				else if (sLine.IndexOf(IMAP_SERVER_RESPONSE_OK) != -1) 
				{
					bResult = true;
					break;
				}
			}

			if (!bResult) 
				throw e_select;

			string sLogStr = "TotalMessages[" + m_nTotalMessages.ToString() + "] ,";
			sLogStr += "RecentMessages[" + m_nRecentMessages.ToString() + "] ,";
			if (m_nFirstUnSeenMsgUID > 0 )
				sLogStr += "FirstUnSeenMsgUID[" + m_nFirstUnSeenMsgUID.ToString() + "] ,";
			//Log(LogTypeEnum.INFO, sLogStr);

		}


        public void GetFolderList(string rootFolder, ref XmlDocument xmlDoc)
        {
            if (!m_bIsLoggedIn)
            {
                try
                {
                    Restore(false, m_useSSL);
                }
                catch (ImapException e)
                {
                    if (e.Type != ImapException.ImapErrorEnum.IMAP_ERR_INSUFFICIENT_DATA)
                        throw e;

                    throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_NOTCONNECTED);
                }
            }
            ImapResponseEnum eImapResponse = ImapResponseEnum.IMAP_SUCCESS_RESPONSE;
            List<String> asResultArray = new List<String>();
            string sCommand = IMAP_LIST_COMMAND;
            sCommand += " " + rootFolder + " \"*\""+ IMAP_COMMAND_EOL;
            //try
            //{
                eImapResponse = SendAndReceive(sCommand, ref asResultArray);
                if (eImapResponse == ImapResponseEnum.IMAP_SUCCESS_RESPONSE)
                {
                    List<IMAPFolder> MasterFolderList = new List<IMAPFolder>();
                    
                    
                    
                    foreach (string result in asResultArray)
                    {
                        if (result.StartsWith(IMAP_LIST_RESPONSE))
                        {
                            string[] list = GetFolderNames(result);
                            ProcessFolders(ref list, 2, MasterFolderList);
                            
                            foreach (String folder in list)
                            {
                                Console.Write("{"+folder.Trim()+"}" + " ");
                                
                                
                            }
                            Console.WriteLine();
                        }
                    }

                    foreach (string result in asResultArray)
                    {
                        if (result.StartsWith(IMAP_LIST_RESPONSE))
                        {
                            string[] list = GetFolderNames(result);
                            ProcessChildFolders(ref list, 2, MasterFolderList);

                            foreach (String folder in list)
                            {
                                Console.Write("{" + folder.Trim() + "}" + " ");


                            }
                            Console.WriteLine();
                        }
                    }

                    //OrganizeIntoSubFolders(null, MasterFolderList);
                    CleanUpFolders(MasterFolderList);
                    xmlDoc = BuildXML(MasterFolderList, rootFolder);


                }
                else throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_SOCKET);
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}

        }       
        
        private void ProcessFolders(ref string[] sourceList, int pos, List<IMAPFolder> folderList)
        {
            // first we get all the top level folders
            if (sourceList.Length == pos)
            {
                folderList.Add(new IMAPFolder(sourceList[1],""));
                return;
            }

            //if (sourceList.Length > pos)
            //{
            //    IMAPFolder newParent = null;
            //    foreach (IMAPFolder folder in folderList)
            //    {
            //        if (folder.FolderName.Equals(sourceList[pos-1]))
            //        {
            //            folder.SubFolders.Add(new IMAPFolder(sourceList[pos]));
            //            newParent = folder;
            //            break;
            //        }
            //    }

            //    ProcessFolders(ref sourceList, ++pos, newParent.SubFolders);
            //}


        }

        private void ProcessChildFolders(ref string[] sourceList, int pos, List<IMAPFolder> folderList)
        {
            if (pos > sourceList.Length - 1)
                return;

            IMAPFolder newFolder = null;
            
            foreach (IMAPFolder folder in folderList)
            {
                // if this folder equals the folder one position up from the current position,
                // create a new folder, set its parent to this folder, then add it to the master list
                if (folder.FolderName.Equals(sourceList[pos-1]))
                {
                    newFolder = new IMAPFolder(sourceList[pos], sourceList[pos-1]);
                    newFolder.ParentFolder = sourceList[pos - 1];
                    newFolder.FolderName = sourceList[pos];
                    folder.SubFolders.Add(newFolder);
                    //folderList.Add(newFolder);
                    break;
                }
            }

            if (newFolder != null)
                folderList.Add(newFolder);

            ProcessChildFolders(ref sourceList, ++pos, folderList);
        }

        //private void OrganizeIntoSubFolders(IMAPFolder currentFolder, List<IMAPFolder> folderList)
        //{
        //    if (currentFolder != null)
        //    {
        //        foreach (IMAPFolder folder in folderList)
        //        {
        //            if (folder.ParentFolder.Equals(currentFolder.FolderName) && !currentFolder.SubFolders.Contains(folder))
        //                currentFolder.SubFolders.Add(folder);
        //        }

        //        return;
        //    }
            
        //    foreach (IMAPFolder folder in folderList)
        //    {
        //        OrganizeIntoSubFolders(folder, folderList);
        //    }
        //}

        private void CleanUpFolders(List<IMAPFolder> folderList)
        {
            List<IMAPFolder> foldersToRemove = new List<IMAPFolder>();

            foreach (IMAPFolder folder in folderList)
            {
                if (!folder.ParentFolder.Equals(""))
                {
                    foldersToRemove.Add(folder);
                }
            }

            foreach (IMAPFolder folder in foldersToRemove)
            {
                folderList.Remove(folder);
            }
        }

        private XmlDocument BuildXML(List<IMAPFolder> folderList, string rootFolder)
        {
            //XmlTextWriter xmlWriter = new XmlTextWriter(new MemoryStream(), Encoding.UTF8);
            //XmlElement root = new XmlElement();
            //xmlWriter.WriteStartDocument();
            //xmlWriter.WriteStartElement("folders");
            //xmlWriter.WriteAttributeString("root", rootFolder);

            //XElement root = new XElement("folders", new XAttribute("root", rootFolder));
            //xmlDoc.Add(root);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            XmlNode root = xmlDoc.CreateElement("folders");
            XmlAttribute attr = xmlDoc.CreateAttribute("root");
            attr.Value = rootFolder;
            root.Attributes.Append(attr);
            xmlDoc.AppendChild(root);
            
            
            foreach (IMAPFolder folder in folderList)
            {
                string path = rootFolder + "/" + folder.FolderName;
                //XElement element = new XElement("folder", new XAttribute("Name", folder.FolderName), new XAttribute("Path", path));
                //root.Add(element);
                //xmlWriter.WriteStartElement("folder");
                //xmlWriter.WriteAttributeString("Name", folder.FolderName);
                //xmlWriter.WriteAttributeString("Path", path);
                XmlNode element = xmlDoc.CreateElement("folder");
                XmlAttribute name = xmlDoc.CreateAttribute("Name");
                name.Value = folder.FolderName;
                XmlAttribute p = xmlDoc.CreateAttribute("Path");
                p.Value = path;

                element.Attributes.Append(name);
                element.Attributes.Append(p);

              
                GetChildFolders(folder, xmlDoc, element, path);

                root.AppendChild(element);
                //xmlWriter.WriteEndElement();
                
            }

            xmlDoc.Normalize();
            return xmlDoc;

        }

        private void GetChildFolders(IMAPFolder folder, XmlDocument xmlDoc, XmlNode parentNode, string path)
        {
            if (folder.SubFolders.Count == 0)
                return;

            foreach (IMAPFolder f in folder.SubFolders)
            {
                string p = path + "/" + f.FolderName;
                //XElement element = new XElement("folder", new XAttribute("Name", f.FolderName), new XAttribute("Path", p));
                //rootElement.Add(element);
                //xmlWriter.WriteStartElement("folder");
                //xmlWriter.WriteAttributeString("Name", f.FolderName);
                //xmlWriter.WriteAttributeString("Path", p);
                XmlNode element = xmlDoc.CreateElement("folder");
                XmlAttribute name = xmlDoc.CreateAttribute("Name");
                name.Value = folder.FolderName;
                XmlAttribute path2 = xmlDoc.CreateAttribute("Path");
                path2.Value = p;

                element.Attributes.Append(name);
                element.Attributes.Append(path2);

                GetChildFolders(f, xmlDoc, element, p);

                parentNode.AppendChild(element);
            }
        }

        /*
            * LIST (\HasNoChildren) "/" INBOX/Travel
            * LIST (\HasNoChildren) "/" "INBOX/Account People/Alexander Goodman"
         * */
        private string[] GetFolderNames(string resultString)
        {
            //List<string> folderNames = new List<string>();
            int idx = resultString.IndexOf(")");

            resultString = resultString.Substring(idx + 1).Trim();


            string[] tokens = resultString.Split(new char[] { ' ' });

            StringBuilder folderStr = new StringBuilder();

            for (int i = 1; i < tokens.Length; i++)
            {
                folderStr.Append(tokens[i]);
                folderStr.Append(" ");
            }

            string folderString = folderStr.ToString().Trim();

            if (folderString.StartsWith("\""))
                folderString = folderString.Substring(1, folderString.Length - 2).Replace("\"","");



            return folderString.Split(new char[] { '/' });

            
        }

        /// <summary>
        /// Examine the sFolder/mailbox after login
        /// </summary>
        /// <param name="sFolder">Mailbox folder</param>
		public void ExamineFolder(string sFolder) 
		{
			if (!m_bIsLoggedIn)
			{
				try
				{
					Restore(false, m_useSSL);
				}
				catch (ImapException e)
				{
					if (e.Type != ImapException.ImapErrorEnum.IMAP_ERR_INSUFFICIENT_DATA)
						throw e;

					throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_NOTCONNECTED);
				}
			}
			
            ImapResponseEnum eImapResponse = ImapResponseEnum.IMAP_SUCCESS_RESPONSE;
			ImapException e_examine   = new ImapException (ImapException.ImapErrorEnum.IMAP_ERR_EXAMINE, sFolder);
			ImapException e_invalidparam = new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_INVALIDPARAM);
			
            if (sFolder.Length == 0)
			{
				throw e_invalidparam;
			}
			if (m_bIsFolderExamined)
			{
				if (m_sMailboxName == sFolder)
				{
					return;
				}
				else m_bIsFolderExamined = false;
			}

            List<String> asResultArray = new List<String>();
			string sCommand = IMAP_EXAMINE_COMMAND;
			sCommand += " " + sFolder +IMAP_COMMAND_EOL;
			
            try
			{
				eImapResponse = SendAndReceive(sCommand, ref asResultArray);
				if (eImapResponse == ImapResponseEnum.IMAP_SUCCESS_RESPONSE)
				{
					m_sMailboxName = sFolder;
					m_bIsFolderExamined = true;
				}
				else throw e_examine;
			}
			catch (Exception e)
			{
				throw e;
			}
			//-------------------------
			// PARSE RESPONSE

			bool bResult = false;
			foreach (string sLine in  asResultArray) 
			{
				// If this is an unsolicited response starting with '*'
				if (sLine.IndexOf(IMAP_UNTAGGED_RESPONSE_PREFIX) != -1) 
				{
					// parse the line by space
					string [] asTokens;
					asTokens = sLine.Split(' ');
					if (asTokens[2] == "EXISTS") 
					{
						// The line will look like "* 2 EXISTS"
						m_nTotalMessages = Convert.ToInt32(asTokens[1]);
					}
					else if (asTokens[2] == "RECENT") 
					{
						// The line will look like "* 2 RECENT"
						m_nRecentMessages = Convert.ToInt32(asTokens[1]);
					}
					else if (asTokens[2] == "[UNSEEN") 
					{
						// The line will look like "* OK [UNSEEN 2]"
						string sUIDPart = asTokens[3].Substring(0, asTokens[3].Length-1);
						m_nFirstUnSeenMsgUID = Convert.ToInt32(sUIDPart);
					}
				}
					// If this line looks like "<command-tag> OK ..."
				else if (sLine.IndexOf(IMAP_SERVER_RESPONSE_OK) != -1) 
				{
					bResult = true;
					break;
				}
			}

			if (!bResult) 
				throw e_examine;

			string sLogStr = "TotalMessages[" + m_nTotalMessages.ToString() + "] ,";
			sLogStr += "RecentMessages[" + m_nRecentMessages.ToString() + "] ,";
			if (m_nFirstUnSeenMsgUID > 0 )
				sLogStr += "FirstUnSeenMsgUID[" + m_nFirstUnSeenMsgUID.ToString() + "] ,";
			
		}

        /// <summary>
        /// Restore the connection using available old data
        /// Select the sFolder if previously selected
        /// </summary>
        /// <param name="bSelectFolder">If true then it selects the folder</param>
		void Restore(bool bSelectFolder, bool useSSL)
		{
			ImapException e_insufficiantdata = new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_INSUFFICIENT_DATA);
			if (m_sHost.Length == 0 ||
				m_sUserId.Length == 0||
				m_sPassword.Length == 0)
			{
				throw e_insufficiantdata;
			}
			try
			{
				m_bIsLoggedIn = false;
				Login(m_sHost, m_nPort, m_sUserId, m_sPassword, useSSL);
				if (bSelectFolder && m_sMailboxName.Length > 0)
				{
					if (m_bIsFolderSelected)
					{
						m_bIsFolderSelected = false;
						SelectFolder(m_sMailboxName);
					}
					else if (m_bIsFolderExamined)
					{
						m_bIsFolderExamined = false;
						ExamineFolder(m_sMailboxName);
					}
					else SelectFolder(m_sMailboxName);
				}
			}
			catch (Exception e)
			{
				throw e;
			}

        }

        #endregion

        #region [QUOTA]

        /// <summary>
        /// Check if enough quota is available
        /// </summary>
        /// <param name="sFolderName">Mailbox folder</param>
        /// <returns>true if enough mail quota</returns>
		public bool HasEnoughQuota(string sFolderName)
		{
			try 
			{
				bool bUnlimitedQuota = false;;
				int nUsedKBytes = 0;
				int nTotalKBytes = 0;
        
				GetQuota(sFolderName, ref bUnlimitedQuota,
					ref nUsedKBytes, ref nTotalKBytes);

				if (bUnlimitedQuota || (nUsedKBytes < nTotalKBytes))
					return true;
				else
					return false;
			}
			catch (ImapException e)
			{
				throw e;
			}		
		}

        /// <summary>
        /// Get the quota for specific folder
        /// </summary>
        /// <param name="sFolderName">Mailbox folder</param>
        /// <param name="bUnlimitedQuota">Is unlimited quota</param>
        /// <param name="nUsedKBytes">Used quota in Kbytes</param>
        /// <param name="nTotalKBytes">Total quota in KBytes</param>
		public void GetQuota(string sFolderName, ref bool bUnlimitedQuota,
			ref int nUsedKBytes, ref int nTotalKBytes)
		{
			ImapResponseEnum eImapResponse = ImapResponseEnum.IMAP_SUCCESS_RESPONSE;
			bool bResult = false;
			bUnlimitedQuota = false;
			nUsedKBytes = 0;
			nTotalKBytes = 0;
			if (!m_bIsLoggedIn)
			{
				try
				{
					Restore(false, m_useSSL);
				}
				catch (ImapException e)
				{
					if (e.Type != ImapException.ImapErrorEnum.IMAP_ERR_INSUFFICIENT_DATA)
						throw e;

					throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_NOTCONNECTED);
				}
			}
			if (sFolderName.Length == 0)
			{
				throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_INVALIDPARAM);
			}

            List<String> asResultArray = new List<String>();
			string sCommand = IMAP_GETQUOTA_COMMAND;
            sCommand += String.Format(" {0}{1}", sFolderName, IMAP_COMMAND_EOL);
			
            try
			{
				eImapResponse = SendAndReceive(sCommand, ref asResultArray);
				if (eImapResponse == ImapResponseEnum.IMAP_SUCCESS_RESPONSE)
				{
					m_sMailboxName = sFolderName;
					m_bIsFolderExamined = true;

                    string quotaPrefix = String.Format("{0} ", IMAP_UNTAGGED_RESPONSE_PREFIX);
                    quotaPrefix += String.Format("{0} ", IMAP_QUOTA_RESPONSE);

					foreach (string sLine in asResultArray)
					{
						if (sLine.StartsWith(quotaPrefix) == true)
						{
							// Find the open and close paranthesis, and extract
							// the part inside out.
							int nStart = sLine.IndexOf('(');
							int nEnd = sLine.IndexOf(')', nStart);
							if (nStart != -1 &&
								nEnd != -1 &&
								nEnd > nStart) 
							{
								string sQuota = sLine.Substring(nStart+1, nEnd-nStart-1 );
								if (sQuota.Length > 0) 
								{
									// Parse the space-delimited quota information which
									// will look like "STORAGE <used> <total>"
									string [] asArrList; // = new ArrayList();
									asArrList = sQuota.Split(' ');

									// get the used and total kbytes from these tokens
									if (asArrList.Length == 3 && String.Compare(asArrList[0], "STORAGE", false) == 0) 
									{
										nUsedKBytes = Convert.ToInt32(asArrList[1],10);;
										nTotalKBytes = Convert.ToInt32(asArrList[2],10);
									}
									else 
									{
                                        string error = String.Format("Invalid Quota information :{0}", sQuota);
										break;
									}
								}
								else 
								{
									bUnlimitedQuota = true;
								}
							}
							else 
							{
                                string error = String.Format("Invalid Quota IMAP Response : {0}", sLine);
								break;
							}
						}
							// If the line looks like "<command-tag> OK ..."
						else if (sLine.IndexOf(IMAP_SERVER_RESPONSE_OK) != -1) 
						{
							bResult = true;
							break;
						}
					}

					if (!bResult) 
						throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_QUOTA);
					if (!bUnlimitedQuota)
					{
                        string sLogStr = String.Format("GETQUOTA used=[{0}], total=[{1}]", nUsedKBytes, nTotalKBytes);
					
					}
				}
			}
			catch (Exception e)
			{
				throw e;
			}

        }

        #endregion

        #region [MESSAGE]

        /// <summary>
        /// Search the messages by specified criterias
        /// </summary>
        /// <param name="asSearchData">Search criterias</param>
        /// <param name="bExactMatch">Is it exact search</param>
        /// <param name="asSearchResult">search result</param>
		public void SearchMessage(string [] asSearchData, bool bExactMatch, ArrayList asSearchResult)
		{

			if (!m_bIsLoggedIn)
			{
				try
				{
					Restore(true, m_useSSL);
				}
				catch (ImapException e)
				{
					if (e.Type != ImapException.ImapErrorEnum.IMAP_ERR_INSUFFICIENT_DATA)
						throw e;

					throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_NOTCONNECTED);
				}
			}

			if (!m_bIsFolderSelected && !m_bIsFolderExamined) 
			{
				throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_NOTSELECTED);
			}

			int nCount = asSearchData.Length;
			if (nCount == 0) 
			{
				throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_INVALIDPARAM);
			}

			//--------------------------
			// PREPARE SEARCH KEY/VALUE
    
			string sCommandSuffix = "";
			foreach (string sLine in asSearchData) 
			{
				if (sLine.Length == 0) 
				{
					throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_INVALIDPARAM);;
				}

				// convert to lower case once for all
				sLine.ToLower();
        
				if (sCommandSuffix.Length > 0)
					sCommandSuffix += " ";
				sCommandSuffix += sLine;
			}

			ImapResponseEnum eImapResponse = ImapResponseEnum.IMAP_SUCCESS_RESPONSE;
			string sCommandString = IMAP_SEARCH_COMMAND + " " + sCommandSuffix;
			sCommandString += IMAP_COMMAND_EOL;

            List<String> asResultArray = new List<String>();
			try
			{
				//-----------------------
				// SEND SEARCH REQUEST
				eImapResponse = SendAndReceive(sCommandString, ref asResultArray);
				if (eImapResponse == ImapResponseEnum.IMAP_SUCCESS_RESPONSE)
				{
					//-------------------------
					// PARSE RESPONSE
					nCount = asResultArray.Count;
					bool bResult = false;
					string sPrefix = IMAP_UNTAGGED_RESPONSE_PREFIX + " ";
					sPrefix += IMAP_SEARCH_RESPONSE;
					foreach (string sLine in asResultArray) 
					{
						int nPos  = sLine.IndexOf(sPrefix );
						if (nPos != -1) 
						{
							nPos += sPrefix.Length ;
							string sSuffix = sLine.Substring(nPos);
							sSuffix.Trim();
							string [] asSearchRes = sSuffix.Split(' ');
							foreach (string sResultLine in asSearchRes)
							{
								asSearchResult.Add(sResultLine);
							}
							bResult = true;
							break;
						}
					}
					if (!bResult) 
					{
						throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_SEARCH, sCommandSuffix);
					}
				}
				else
					throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_SEARCH, asResultArray[0].ToString());
			}
			catch (ImapException e)
			{
				LogOut();
				throw e;
			}	

		}


        /// <summary>
        /// Fetch the body for specified part
        /// </summary>
        /// <param name="sMessageUID"> Message uid</param>
        /// <param name="sMessagePart">Message part</param>
        /// <param name="aArray">Body data as Array</param>
		public void FetchPartBody(string sMessageUID,
			string sMessagePart,
			ref string sData)
		{
			if (!m_bIsLoggedIn)
			{
				try
				{
					Restore(true, m_useSSL);
				}
				catch (ImapException e)
				{
					if (e.Type != ImapException.ImapErrorEnum.IMAP_ERR_INSUFFICIENT_DATA)
						throw e;

					throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_NOTCONNECTED);
				}
			}
			if (!m_bIsFolderSelected && !m_bIsFolderExamined) 
			{
				throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_NOTSELECTED);
			}
			if (sMessageUID.Length == 0)
				throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_INVALIDPARAM);
			string sPart = sMessagePart;
			if (sPart.Length == 0 )
				sPart = IMAP_MSG_DEFAULT_PART;
			try
			{
				
				GetBody(sMessageUID,sPart, ref sData);
				
			}
			catch (ImapException e)
			{
				throw e;
			}
		}


        /// <summary>
        /// Fetch Header of the message uid and part
        /// </summary>
        /// <param name="sMessageUID"> Message UID</param>
        /// <param name="sMessagePart"> Message part</param>
        /// <param name="asMessageHeader">Output Array</param>
		public void FetchPartHeader(string sMessageUID,
			string sMessagePart,
			ArrayList asMessageHeader)
		{
			if (!m_bIsLoggedIn)
			{
				try
				{
					Restore(true, m_useSSL);
				}
				catch (ImapException e)
				{
					if (e.Type != ImapException.ImapErrorEnum.IMAP_ERR_INSUFFICIENT_DATA)
						throw e;

					throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_NOTCONNECTED);
				}
			}
			if (!m_bIsFolderSelected && !m_bIsFolderExamined) 
			{
				throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_NOTSELECTED);
			}
			if (sMessageUID.Length == 0)
				throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_INVALIDPARAM);
			string sPart = sMessagePart;
			if (sPart.Length == 0 )
				sPart = IMAP_MSG_DEFAULT_PART;
			try 
			{
				GetHeader (sMessageUID, sPart, asMessageHeader);
			}
			catch (ImapException e)
			{
				throw e;
			}
		}


		/// <summary>
		/// Fetch the full message
		/// </summary>
		/// <param name="sMessageUID">Message UID </param>
		/// <param name="oXmlDoc">Message is stored as XmlDocument object</param>
		public void FetchMessage(string sMessageUID, XmlWriter oXmlWriter, bool bFetchBody)
		{
			if (!m_bIsLoggedIn)
			{
				try
				{
					Restore(true, m_useSSL);
				}
				catch (ImapException e)
				{
					if (e.Type != ImapException.ImapErrorEnum.IMAP_ERR_INSUFFICIENT_DATA)
						throw e;

					throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_NOTCONNECTED);
				}
			}
			if (!m_bIsFolderSelected && !m_bIsFolderExamined) 
			{
				throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_NOTSELECTED);
			}
			try 
			{
				ArrayList asMessageHeader = new ArrayList();
				GetHeader( sMessageUID, "0", asMessageHeader);
				oXmlWriter.WriteStartElement("Part");
				oXmlWriter.WriteAttributeString("ID", "0");
				int nCount = asMessageHeader.Count;
				for (int i = 0; i < nCount; i = i + 2)
				{
					oXmlWriter.WriteElementString(asMessageHeader[i].ToString(),asMessageHeader[i + 1].ToString());
				}
				
				if (!IsMultipart (asMessageHeader))
				{
					oXmlWriter.WriteStartElement("Part");
					oXmlWriter.WriteAttributeString("ID", "1");
				}
				/*else
				{
					oXmlWriter.WriteStartElement("Part");
					oXmlWriter.WriteAttributeString("ID", "0");

				}*/
				
				GetBodyStructure(sMessageUID, oXmlWriter, bFetchBody);
				oXmlWriter.WriteEndElement();
			}
			catch (ImapException e)
			{
				throw e;
			}
		}

		/// <summary>
		/// Get the Body structure of the message.
		/// If message is single part then first part is 1
		/// If message is multipart then first part is 0
		/// </summary>
		/// <param name="sMessageUID"> Message UID</param>
		/// <param name="oXmlElem"> Body structure as XmlElement</param>
		void GetBodyStructure(string sMessageUID, XmlWriter oXmlWriter, bool bFetchBody)
		{
			ImapResponseEnum eImapResponse = ImapResponseEnum.IMAP_SUCCESS_RESPONSE;
			string sCommandSuffix = sMessageUID + " " + "BODYSTRUCTURE";
			string sCommandString = IMAP_UIDFETCH_COMMAND + " " + sCommandSuffix + IMAP_COMMAND_EOL ;
			
			try
			{
				//-----------------------
				// SEND SEARCH REQUEST
                List<String> asResultArray = new List<String>();
				eImapResponse = SendAndReceive(sCommandString, ref asResultArray);
				if (eImapResponse == ImapResponseEnum.IMAP_SUCCESS_RESPONSE)
				{
					string sLastLine = IMAP_SERVER_RESPONSE_OK;
					string sBodyStruct = "";
					bool bResult = false;
					int nStart = -1;
					foreach (string sLine in asResultArray)
					{
						nStart = sLine.IndexOf(IMAP_BODYSTRUCTURE_COMMAND);
						if (sLine.StartsWith(IMAP_UNTAGGED_RESPONSE_PREFIX) &&
							(nStart != -1))
						{
							sBodyStruct = sLine;
						}
						else if (sLine.StartsWith(sLastLine))
						{
							bResult = true;
							break;
						}
					}
					if (!bResult)
					{
						throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_FETCHBODYSTRUCT);
					}
					else if (sBodyStruct.Length == 0)
						return;
					
					nStart = sBodyStruct.IndexOf(IMAP_BODYSTRUCTURE_COMMAND);
					sBodyStruct = sBodyStruct.Substring(nStart + IMAP_BODYSTRUCTURE_COMMAND.Length);
					int nEnd = sBodyStruct.LastIndexOf(")");
					if (nEnd == -1)
					{
						throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_FETCHBODYSTRUCT);
					}
					sBodyStruct = sBodyStruct.Substring(0, nEnd);
					string sPartPrefix = "";
					if (!ParseBodyStructure(sMessageUID, ref sBodyStruct, oXmlWriter, sPartPrefix, bFetchBody))
						throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_FETCHBODYSTRUCT);
				}
				else
				{
					throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_FETCHMSG, sCommandSuffix );
				}
			
			}
			catch (ImapException e)
			{
				LogOut();
				throw e;
			}
		}



    	/// <summary>
        /// Parse the bodystructure and store as XML Element
	    /// </summary>
	    /// <param name="sMessageUID"></param>
	    /// <param name="sBodyStruct"></param>
	    /// <param name="oXmlBodyPart"></param>
	    /// <param name="sPartPrefix"></param>
	    /// <param name="bFetchBody"></param>
	    /// <returns></returns>
		bool ParseBodyStructure(string sMessageUID, ref string sBodyStruct, XmlWriter oXmlBodyPart,
			string sPartPrefix, bool bFetchBody)
		{
			
			bool bMultiPart = false;
			string sTemp = "";
			ArrayList asAttrs = new ArrayList();
			sBodyStruct = sBodyStruct.Trim();

			//Check if this is NIL
			if (IsNilString (ref sBodyStruct))
				return true;
			//Look for '('
			if (sBodyStruct[0] == '(')
			{
				//Check if multipart or singlepart.
				//Multipart will have another '(' here
				// and single part will not.
				char ch;
				ch = sBodyStruct[1];
				if (ch != '(')
				{
					//Singal part
					if (ch == ')')
					{
						sBodyStruct = sBodyStruct.Substring(2);
						return true;
					}
					//remove opening paranthesis
					sBodyStruct = sBodyStruct.Substring(1);
					string sType = "";
					string sSubType = "";
					if (!GetContentType(ref sBodyStruct, ref sType, ref sSubType, ref sTemp))
					{
						return false;
					}
					asAttrs.Add(IMAP_MESSAGE_CONTENT_TYPE);
					asAttrs.Add(sTemp);

					// Message-id (optional)
					if (!ParseQuotedString( ref sBodyStruct, ref sTemp )) 
					    return false;
					
					if (sTemp.Length > 0) 
					{
						asAttrs.Add(IMAP_MESSAGE_ID);
						asAttrs.Add(sTemp);
					}
					// Content-Description (optional)
					if (!ParseQuotedString( ref sBodyStruct, ref sTemp )) 
						return false;
					
					if (sTemp.Length > 0) 
					{
						asAttrs.Add(IMAP_MESSAGE_CONTENT_DESC);
						asAttrs.Add(sTemp);
					}

					// Content-Transfer-Encoding
					if (!ParseQuotedString( ref sBodyStruct, ref sTemp )) 					
						return false;
					
					asAttrs.Add(IMAP_MESSAGE_CONTENT_ENCODING);
					asAttrs.Add(sTemp);

					// Content Size in bytes
					if (!ParseString( ref sBodyStruct, ref sTemp ))
                        return false;
					
					asAttrs.Add(IMAP_MESSAGE_CONTENT_SIZE);
					asAttrs.Add(sTemp);
					sTemp = sType + "/" + sSubType;

					if (sTemp.ToLower() == IMAP_MESSAGE_RFC822.ToLower()) //email attachment
					{
						if (!ParseEnvelope(ref sBodyStruct, asAttrs ))						
							return false;
						
						if (!ParseBodyStructure(sMessageUID, ref sBodyStruct, oXmlBodyPart,sPartPrefix, bFetchBody )) 						
							return false;
						
						// No of Lines in the message
						if (!ParseString(ref sBodyStruct, ref sTemp )) 						
							return false;
						
						if (sTemp.Length > 0) 
						{
							asAttrs.Add(IMAP_MESSAGE_CONTENT_LINES);
							asAttrs.Add(sTemp);
						}
					}
					else if (sType == "text") //simple text
					{
						// No of Lines in the message
						if (!ParseString(ref sBodyStruct, ref sTemp )) 					
							return false;
						
						if (sTemp.Length > 0) 
						{
							asAttrs.Add(IMAP_MESSAGE_CONTENT_LINES);
							asAttrs.Add(sTemp);
						}
					}
					// MD5 CRC Error Check
					// Don't know what to do with it
					if (sBodyStruct[0] == ' ') 
					{
						if (!ParseString( ref sBodyStruct, ref sTemp ))
						   return false;
					}
				}
				else // MULTIPART
				{
					bMultiPart = true;
					// remove the open paranthesis
					sBodyStruct = sBodyStruct.Substring(1);
					uint nPartNumber = 0;
					string sPartNumber= "";
					do 
					{
						// prepare next part number
						nPartNumber++;
                
						if (sPartPrefix.Length > 0) 
							sPartNumber = sPartPrefix + "." +  nPartNumber.ToString();
						else
							sPartNumber = nPartNumber.ToString();

						//XmlElement oXmlChildPart;
						oXmlBodyPart.WriteStartElement("Part");
						oXmlBodyPart.WriteAttributeString("ID",sPartNumber);
						// add a new child to the part with
						// an empty attribute array. This array will be filled
						// in the "if" condition block.
						int nCount = asAttrs.Count;
						for (int i = 0; i < nCount; i = i + 2)
						{
							oXmlBodyPart.WriteElementString(asAttrs[i].ToString(),asAttrs[i + 1].ToString());
						}
						if (sPartNumber.Length > 0 && 
							sPartNumber != "0" &&
							bFetchBody == true)
						{
							try
							{
								string sData = "";
								GetBody(sMessageUID, sPartNumber, ref sData);
								if (sData.Length > 0 &&
									((sData.ToLower()).IndexOf(IMAP_MESSAGE_CONTENT_TYPE.ToLower()) == -1))
								{
									oXmlBodyPart.WriteElementString("DATA", sData);
								}
							}
							catch (ImapException)
							{
								return false;
							}
						}
						
						
						// add a new child to the part with
						// an empty attribute array. This array will be filled
						// in the "if" condition block.
						//oXmlBodyPart.AppendChild(oXmlChildPart);
						// parse this body part
						if (!ParseBodyStructure(sMessageUID, ref sBodyStruct, oXmlBodyPart,
							sPartNumber, bFetchBody)) 
						{
							return false;
						}
					  oXmlBodyPart.WriteEndElement();
					}
					while (sBodyStruct[0] == '('); // For each body part
					// Content-type
					string sType = IMAP_MESSAGE_MULTIPART;
					string sSubType = "";
					if (!GetContentType(ref sBodyStruct, ref sType, ref sSubType,
						ref sTemp )) 
					{
						return false;
					}
					asAttrs.Add(IMAP_MESSAGE_CONTENT_TYPE);
					asAttrs.Add(sTemp);
				}
				//----------------------------------
				// COMMON FOR SINGLE AND MULTI PART
        
				// Disposition
				if (sBodyStruct[0] == ' ') 
				{
					if (!GetContentDisposition(ref sBodyStruct, ref sTemp )) 					
						return false;
					
					if (sTemp.Length > 0) 
					{
						asAttrs.Add(IMAP_MESSAGE_CONTENT_DISP);
						asAttrs.Add(sTemp);
					}
				}
				// Language
				if (sBodyStruct[0] == ' ')
				{
					if (!ParseLanguage(ref sBodyStruct, ref sTemp ))
						return false;
				}
				// Extension data
				while (sBodyStruct[0] == ' ')
					if (!ParseExtension(ref sBodyStruct, ref sTemp ))
						return false;

				// this is the end of the body part
				if (!FindAndRemove(ref sBodyStruct, ')' ))
					return false;
            
				// Finally, set the attribute array to the part
				// EXCEPTION : if multipart and this is the root
				// part, the header is already prepared in the
				// GetBodyStructure function and hence DO NOT set it.
        
				if (!bMultiPart || sPartPrefix.Length > 0)
				{
					int nCount = asAttrs.Count;
					for (int i = 0; i < nCount ; i= i+2)
					{
						oXmlBodyPart.WriteElementString(asAttrs[i].ToString(), asAttrs[i+1].ToString());
					}
					
				}
				return true;
			}
			
			return false;
		}

        /// <summary>
        /// Get the message body for specified part
        /// </summary>
        /// <param name="sMessageUid">Message uid</param>
        /// <param name="sPartNumber">Body part</param>
        /// <param name="aArray">Out data</param>
		void GetBody(string sMessageUid, string sPartNumber, ref string sData)
		{
			ImapResponseEnum eImapResponse = ImapResponseEnum.IMAP_SUCCESS_RESPONSE;
			string sCommandSuffix = "";
			sCommandSuffix = sMessageUid + " " + "BODY[" + sPartNumber + "]";
			string sCommandString = IMAP_UIDFETCH_COMMAND + " " + sCommandSuffix + IMAP_COMMAND_EOL ;
		
			try
			{
				//-----------------------
				// SEND SEARCH REQUEST
				ArrayList asResultArray = new ArrayList();
				eImapResponse = SendAndReceiveByNumLines(sCommandString, ref asResultArray, 1);
				if (eImapResponse == ImapResponseEnum.IMAP_SUCCESS_RESPONSE)
				{
					//-------------------------
					// PARSE RESPONSE
					string sLastLine = IMAP_COMMAND_IDENTIFIER + " " + IMAP_OK_RESPONSE;
					string sLine = asResultArray[0].ToString();
					if (!sLine.StartsWith(IMAP_UNTAGGED_RESPONSE_PREFIX))
					{
						string sLog = "InValid Message Response " + sLine + ".";
						
						throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_FETCHMSG);
					}
					long lMessageSize = GetResponseSize(sLine);
					if (lMessageSize == 0L)
					{
						string sLog = "InValid Message Response " + sLine + ".";
						
						throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_FETCHMSG);
					}
                    sData = "";
					ReceiveBuffer(ref sData,Convert.ToInt32(lMessageSize));
					if (sData.Length == 0) 
					{
						throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_FETCHMSG, sCommandSuffix ); 
					}
                    //Convert.FromBase64String(sData).ToString();
					eImapResponse = Receive(ref asResultArray);
					if (eImapResponse != ImapResponseEnum.IMAP_SUCCESS_RESPONSE)
						throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_FETCHMSG, sCommandSuffix );
		
                   /***
					int nCount = asResultArray.Count;
					for (int i = 1; i < nCount; i++)
					{
						string sTmpData = asResultArray[i].ToString();
						if (sTmpData.Length > 0)
						{
							if (sTmpData[0] == ')' ||
								(sTmpData.IndexOf(IMAP_SERVER_RESPONSE_OK) != -1))
							{
								break;
							}
							else
								sData += sTmpData;
						}
						
					}****/
				}
				else
					throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_FETCHMSG, sCommandSuffix );
			}
			catch (ImapException e)
			{
				LogOut();
				throw e;
			}	
		}

        /// <summary>
        /// Get the header for specific partNumber and Message UID
        /// </summary>
        /// <param name="sMessageUid">Unique Identifier of message</param>
        /// <param name="sPartNumber"> Message part number</param>
        /// <param name="asMessageHeader">Return array </param>
		void GetHeader (string sMessageUid, string sPartNumber, ArrayList asMessageHeader)
		{
			asMessageHeader.Clear();
			ImapResponseEnum eImapResponse = ImapResponseEnum.IMAP_SUCCESS_RESPONSE;
			string sCommandSuffix = "";
			if (sPartNumber == "0")
			{
				sCommandSuffix = sMessageUid + " " + "BODY[HEADER]" ;
			}
			else
			{
				sCommandSuffix = sMessageUid + " " + "BODY[" + sPartNumber + ".MIME]";
			}
			string sCommandString = IMAP_UIDFETCH_COMMAND + " " + sCommandSuffix + IMAP_COMMAND_EOL ;
		
			try
			{
				//-----------------------
				// SEND SEARCH REQUEST
                List<String> asResultArray = new List<String>();
				eImapResponse = SendAndReceive(sCommandString, ref asResultArray);
				if (eImapResponse == ImapResponseEnum.IMAP_SUCCESS_RESPONSE)
				{
					//-------------------------
					// PARSE RESPONSE
					string sKey = "";
					string sValue = "";
					string sLastLine = IMAP_SERVER_RESPONSE_OK;
					foreach (string sLine in asResultArray)
					{
						if (sLine.Length <= 0 ||
							sLine.StartsWith(IMAP_UNTAGGED_RESPONSE_PREFIX) ||
							sLine == ")" )
						{
							continue;
						}
						else if(sLine.StartsWith(sLastLine))
						{
							break;

						}
						int nPos = sLine.IndexOf(" ");
						if (nPos != -1)
						{
							string sTmpLine = sLine.Substring(0, nPos);
							nPos = sTmpLine.IndexOf(":");
						}
						if (nPos != -1)
						{
							if (sKey.Length > 0 )
							{
								asMessageHeader.Add(sKey);
								asMessageHeader.Add(sValue);
							}
							sKey = sLine.Substring(0, nPos).Trim();
							sValue = sLine.Substring(nPos + 1).Trim();
						}
						else
						{
							sValue += sLine.Trim();
						}
					}
					if (sKey.Length > 0 )
					{
						asMessageHeader.Add(sKey);
						asMessageHeader.Add(sValue);
					}
					
				}
				else
					throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_FETCHMSG, sCommandSuffix );
			}
			catch (ImapException e)
			{
				LogOut();
				throw e;
			}	


		}

        /// <summary>
/// Check if this message is multipart
/// To Identify multipart message, the content-type is either
/// multipart or rfc822
/// </summary>
/// <param name="asHeader"></param>
/// <returns></returns>
		public bool IsMultipart(ArrayList asHeader)
		{	
			for (int i = 0 ; i < asHeader.Count; i = i+ 2)
			{
				if ( asHeader[i].ToString().ToLower() == IMAP_MESSAGE_CONTENT_TYPE.ToLower())
				{
					string sValue = asHeader[i+1].ToString();
					sValue = sValue.ToLower();
					if (sValue.StartsWith( IMAP_MESSAGE_MULTIPART.ToLower() ) ||
						sValue.StartsWith( IMAP_MESSAGE_RFC822.ToLower() ))
					{
						return true;
					}
					else
						return false;
				}
			}
			return false;
		}

		/// <summary>
		/// Returns true if starts with NIL
		/// </summary>
		/// <param name="sBodyStruct">Body Structure</param>
		/// <returns>true/false</returns>
		bool IsNilString(ref string sBodyStruct)
		{
			string sSub = sBodyStruct.Substring(0, 3);
			if (sSub == IMAP_MESSAGE_NIL ) 
			{
				sBodyStruct = sBodyStruct.Substring(3);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Get the content type
		/// </summary>
		/// <param name="sBodyStruct">Body Structure</param>
		/// <param name="sType">Content Type</param>
		/// <param name="sSubType">Sub Type</param>
		/// <param name="sContentType">Content Type Value</param>
		/// <returns>True/false</returns>
		bool GetContentType(ref string sBodyStruct,
			ref string sType,
			ref string sSubType,
			ref string sContentType)
		{
			sContentType = IMAP_PLAIN_TEXT;

			// get the type and the subtype strings from body struct
			// If not found, set it to the default value plain/text.

			if (sType.Length < 1) 
			{
				if (!ParseQuotedString( ref sBodyStruct, ref sType )) 
					return false;				
			}
			sSubType = "";
			if (!ParseQuotedString( ref sBodyStruct, ref sSubType )) 			
				return false;
			
    
			if (sType.Length > 0 && sSubType.Length > 0 ) 
			{
				sContentType = sType + "/" + sSubType;
			}
    
			// Add extra parameters (if any) to the Content-type
			ArrayList asParam = new ArrayList();
			if (!ParseParameters( ref sBodyStruct, asParam )) 			
				return false;
			
			for (int i=0; i < asParam.Count; i+=2) 
			{
                string sTemp = String.Format("; {0}=\"{1}\"", asParam[i], asParam[i + 1]);
				sContentType += sTemp;
			}
			return true;
		}

		/// <summary>
		/// Get Content Disposition
		/// </summary>
		/// <param name="sBodyStruct"> Body Structure</param>
		/// <param name="sDisp">Content Disposition</param>
		/// <returns>true if success</returns>
		bool GetContentDisposition(ref string sBodyStruct,
			ref string sDisp)
		{
			sDisp = "";
			
			// remove any spaces at the beginning and the end
			sBodyStruct = sBodyStruct.Trim();

			// check if this is NIL
			if (IsNilString(ref sBodyStruct)) 
				return true;

			// find and remove opening paranthesis
			if (!FindAndRemove( ref sBodyStruct, '(' ))
				return false;

			// get the content disposition type (inline/attachment)
			if (!ParseQuotedString( ref sBodyStruct, ref sDisp)) 			
				return false;
			
			// get the associated parameters if any
			ArrayList asParam = new ArrayList();
			if (!ParseParameters( ref sBodyStruct, asParam ))			
				return false;
			
			// prepare the content-disposition
			string sTemp = "";
			for (int i=0; i < asParam.Count; i+=2) 
			{
				sTemp = "; " + asParam[i].ToString() + "=\"" + asParam[i+1].ToString() + "\"";
				sDisp += sTemp;
			}
			// remove the closing paranthesis
			return FindAndRemove( ref sBodyStruct, ')' );
        }

#endregion

        #region [PARSERS]

        /// <summary>
		/// Parse the quoted string in body structure
		/// </summary>
		/// <param name="sBodyStruct">Body Structure</param>
		/// <param name="sString">"Quoted string</param>
		/// <returns></returns>
		bool ParseQuotedString(ref string sBodyStruct, ref string sString)
		{
			sString = "";
    
			// remove any spaces at the beginning and the end
			sBodyStruct = sBodyStruct.Trim();

			// check if this is NIL
			if (IsNilString(ref sBodyStruct)) 
				return true;;

			if (sBodyStruct[0] == '"') 
			{
				// extract the part within quotes
				char ch;
				int nEnd;
				for (nEnd = 1; (ch = sBodyStruct[nEnd]) != '"'; nEnd++) 
				{
					if (ch == '\\') 
						nEnd++;
				}
				sString = sBodyStruct.Substring( 1, nEnd-1 );
				sBodyStruct = sBodyStruct.Substring( nEnd+1 );
				return true;
			}
			string sLog = "InValid Body Structure " + sBodyStruct + ".";
			
			return false;
		}

		/// <summary>
		/// Parse the string (seperated by spaces or parenthesis)
		/// </summary>
		/// <param name="sBodyStruct">Body Struct</param>
		/// <param name="sString">string</param>
		/// <returns></returns>
		bool ParseString(ref string sBodyStruct, ref string sString)
		{
			sString = "";
    
			// remove any spaces at the beginning and the end
			sBodyStruct = sBodyStruct.Trim();
			// check if this is NIL
			if (IsNilString(ref sBodyStruct)) 
				return true;

			// extract the literal as whole looking for a
			// space or closing paranthesis character
			char ch;
			int nEnd, nLen;
			nLen = sBodyStruct.Length;

			for (nEnd = 0; nEnd < nLen; nEnd++) 
			{
				ch = sBodyStruct[nEnd];

				if (ch == ' ' || ch == ')') 
					break;
			}

			if (nEnd > 0) 
			{
				sString = sBodyStruct.Substring(0, nEnd);
				sBodyStruct = sBodyStruct.Substring( nEnd );
			}
			return true;
		}

        /// <summary>
        /// Parse the language or list of languages in body structure
        /// </summary>
        /// <param name="sBodyStruct">Bosy structure</param>
        /// <param name="sString">Languages</param>
        /// <returns>true if success</returns>		
		bool ParseLanguage(ref string sBodyStruct, ref string sString)
		{
			sString = "";
    
			// remove any spaces at the beginning and the end
			sBodyStruct = sBodyStruct.Trim();

			if (sBodyStruct[0] == '(') 
			{ // Language list

				// remove the opening paranthesis
				if (!FindAndRemove( ref sBodyStruct, '('))
					return false;

				// TO DO
				// Logic for parsing language list is not yet
				// written. To be added in the future.

				// remove the closing paranthesis
				if (!FindAndRemove( ref sBodyStruct, ')'))
					return false;
			}
			else 
			{ // One or no language

				if (!ParseQuotedString(ref sBodyStruct, ref sString)) 				
					return false;
				
			}
        
			return true;
		}

        /// <summary>
        /// Parse the parameter in body structure
        /// </summary>
        /// <param name="sBodyStruct">Body structure</param>
        /// <param name="asParams">parameter</param>
        /// <returns>true if success</returns>
		bool ParseParameters(ref string sBodyStruct,
			ArrayList asParams)
		{
			// remove any spaces at the beginning and the end
			sBodyStruct = sBodyStruct.Trim();

			// check if this is NIL
			if (IsNilString(ref sBodyStruct)) 
				return true;

			// remove the opening paranthesis
			if (!FindAndRemove(ref sBodyStruct, '('))
				return false;
    
			string sName = "";
			string sValue = "";
			while (sBodyStruct[0] != ')') 
			{
        
				// Name
				if (!ParseQuotedString( ref sBodyStruct, ref sName )) 				
					return false;
				
        
				// Value
				if (!ParseQuotedString(ref  sBodyStruct, ref sValue )) 				
					return false;
				
				asParams.Add(sName);
				asParams.Add(sValue);
			}

			// remove the closing paranthesis
			return FindAndRemove(ref sBodyStruct, ')');
		}
        
        /// <summary>
/// Parse the extension in body structure
/// </summary>
/// <param name="sBodyStruct">body structure</param>
/// <param name="sString">extension</param>
/// <returns>true if success</returns>
		bool ParseExtension(ref string sBodyStruct, ref string sString)
		{
			sString = "";
    
			// remove any spaces at the beginning and the end
			sBodyStruct = sBodyStruct.Trim();

			// check if this is NIL
			if (IsNilString(ref sBodyStruct)) 
				return true;

			// TO DO
			// Dont know what to do with the data.

			return true;
		}
        
        /// <summary>
        /// Parse the address string
        /// </summary>
        /// <param name="sBodyStruct">body structure</param>
        /// <param name="sString">address</param>
        /// <returns>true if success</returns>
		bool ParseAddressList(ref string sBodyStruct, ref string sString)
		{
			sString = "";
    
			// remove any spaces at the beginning and the end
			sBodyStruct = sBodyStruct.Trim();

			// check if this is NIL
			if (IsNilString(ref sBodyStruct)) 
				return true;

			// remove the opening paranthesis
			if (!FindAndRemove( ref sBodyStruct, '('))
				return false;

			// process each address
			string sAddress = "";
			while (sBodyStruct[0] == '(') 
			{ 

				// Get each address in the list
				if (!ParseAddress(ref sBodyStruct, ref sAddress)) 
				{
					return true;
				}

				// prepare the address list (as comma separated
				// list of addresses).
				if (sAddress.Length > 0) 
				{
					if (sString.Length > 0) 
						sString += ", ";
					sString += sAddress;
				}

				sBodyStruct = sBodyStruct.Trim();
			}

			// remove the closing paranthesis
			return FindAndRemove( ref sBodyStruct, ')');
		}
        
        /// <summary>
        /// Parse one address and format the string
        /// </summary>
        /// <param name="sBodyStruct">body structure</param>
        /// <param name="sString">address</param>
        /// <returns>true if success</returns>
		bool ParseAddress(ref string sBodyStruct, ref string sString)
		{
			sString = "";
    
			// remove any spaces at the beginning and the end
			sBodyStruct = sBodyStruct.Trim();

			// check if this is NIL
			if (IsNilString(ref sBodyStruct)) 
				return true;

			// remove the opening paranthesis
			if (!FindAndRemove( ref sBodyStruct, '('))
				return false;

			string sPersonal = "";
			string sEmailId = "";
			string sEmailDomain = "";
			string sTemp = "";
    
			// Personal Name
			if (!ParseQuotedString( ref sBodyStruct, ref sPersonal )) // "Failed getting the Personal Name."			
				return false;
			
			// At Domain List (Right now, don't know what to do with this)
			if (!ParseQuotedString( ref sBodyStruct, ref sTemp )) //"Failed getting the Domain List."			
				return false;
			
			// Email Id
			if (!ParseQuotedString( ref sBodyStruct, ref sEmailId )) //"Failed getting the Email Id."			
				return false;
			
			// Email Domain
			if (!ParseQuotedString( ref sBodyStruct, ref sEmailDomain )) //"Failed getting the Email Domain."			
				return false;
			

			if (sEmailId.Length > 0) 
			{
				if (sPersonal.Length > 0) 
				{
					if (sEmailDomain.Length > 0) 
					{
						sString = sPersonal + " <" +
							      sEmailId  + "@" + 
							      sEmailDomain + ">";
					}   
					else 
					{
						sString = sPersonal + " <" +
								  sEmailId + ">";
					}
				}
				else 
				{
					if (sEmailDomain.Length > 0) 
					{
						sString = sEmailId + "@" + sEmailDomain;
					}
					else 
					{
						sString = sEmailId;
					}    
				}
			}

			// remove the closing paranthesis
			return FindAndRemove(ref sBodyStruct, ')');
		}

		bool ParseEnvelope(ref string sBodyStruct,
			ArrayList asAttrs)
		{
			// remove any spaces at the beginning and the end
			sBodyStruct = sBodyStruct.Trim();

			// check if this is NIL
			if (IsNilString(ref sBodyStruct ))
				return true;

			// look for '(' character
			if (!FindAndRemove(ref sBodyStruct, '('))
				return false;

			string sTemp = "";
			// Date
			if (!ParseQuotedString( ref sBodyStruct, ref sTemp )) //"Invalid Message Envelope Date."			
				return false;
			
			if (sTemp.Length > 0) 
			{
				asAttrs.Add(IMAP_HEADER_DATE_TAG );
				asAttrs.Add(sTemp);
			}

			// Subject
			if (!ParseQuotedString( ref sBodyStruct, ref sTemp )) //"Invalid Message Envelope Subject."			
				return false;
			
			if (sTemp.Length > 0)
			{
				asAttrs.Add(IMAP_HEADER_SUBJECT_TAG);
				asAttrs.Add(sTemp );
			}

			// From
			if (!ParseAddressList(ref sBodyStruct, ref sTemp )) //"Invalid Message Envelope From."			
				return false;
			
			if (sTemp.Length > 0) 
			{
				asAttrs.Add(IMAP_HEADER_FROM_TAG);
				asAttrs.Add(sTemp);
			}
    
			// Sender
			if (!ParseAddressList(ref sBodyStruct, ref sTemp )) //"Invalid Message Envelope Sender."			
				return false;
			
			if (sTemp.Length > 0) 
			{
				asAttrs.Add(IMAP_HEADER_SENDER_TAG);
				asAttrs.Add(sTemp);
			}
        
			// ReplyTo
			if (!ParseAddressList(ref sBodyStruct, ref sTemp )) //"Invalid Message Envelope Reply-To			
				return false;
			
			if (sTemp.Length > 0) 
			{
				asAttrs.Add(IMAP_HEADER_REPLY_TO_TAG);
				asAttrs.Add(sTemp);
			}
        
			// To
			if (!ParseAddressList(ref sBodyStruct, ref sTemp )) //"Invalid Message Envelope To.			
				return false;
			
			if (sTemp.Length > 0) 
			{
				asAttrs.Add(IMAP_HEADER_TO_TAG);
				asAttrs.Add(sTemp);
			}

			// Cc
			if (!ParseAddressList(ref sBodyStruct, ref sTemp )) //"Invalid Message Envelope CC."			
				return false;
			
			if (sTemp.Length > 0) 
			{
				asAttrs.Add(IMAP_HEADER_CC_TAG);
				asAttrs.Add(sTemp);
			}

			// Bcc
			if (!ParseAddressList(ref sBodyStruct, ref sTemp )) //"Invalid Message Envelope BCC."			
				return false;
			
			if (sTemp.Length > 0) 
			{
				asAttrs.Add(IMAP_HEADER_BCC_TAG);
				asAttrs.Add(sTemp);
			}

			// In-Reply-To
			if (!ParseQuotedString( ref sBodyStruct, ref sTemp )) //"Invalid Message Envelope In-Reply-To."			
				return false;
			
			if (sTemp.Length > 0) 
			{
				asAttrs.Add(IMAP_HEADER_IN_REPLY_TO_TAG);
				asAttrs.Add(sTemp);
			}

			// Message Id
			if (!ParseQuotedString( ref sBodyStruct, ref sTemp )) //"Invalid Message Envelope Message Id."			
				return false;
			
			if (sTemp.Length > 0) 
			{
				asAttrs.Add(IMAP_MESSAGE_ID);
				asAttrs.Add(sTemp);
			}

			// remove the closing paranthesis
			return FindAndRemove(ref sBodyStruct, ')' );
        }

        #endregion


        /// <summary>
        /// find the given character and remove
        /// </summary>
        /// <param name="sBodyStruct">body structure</param>
        /// <param name="ch">first character to find and remove</param>
        /// <returns>true if success</returns>
		bool FindAndRemove(ref string sBodyStruct, char ch)
		{
			sBodyStruct = sBodyStruct.Trim();
			if (sBodyStruct[0] != ch) 
			{
				string sLog = "Invalid Body Structure " + sBodyStruct + ".";
				return false;
			}

			// remove character
			sBodyStruct = sBodyStruct.Substring(1);

			return true;
		}
        
        /// <summary>
        /// Get the Size of the fetch command response
        /// response will look like "{<size>}"
        /// </summary>
        /// <param name="sResponse"></param>
        /// <returns></returns>
		long GetResponseSize(string sResponse)
		{
			// check if there is a size element
			// if not, then the message part number is wrong

			if (sResponse.IndexOf(IMAP_MESSAGE_NIL) != -1) 			
				return 0L;			

			
			int nStart = sResponse.IndexOf('{');
			if (nStart == -1) 
			{				
				throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_INVALIDHEADER);
			}
			int nEnd = sResponse.IndexOf('}');
			if (nEnd == -1 || nEnd < nStart) 
			{
				throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_INVALIDHEADER);
			}

			string sSize = sResponse.Substring( nStart+1, (nEnd - nStart -1));
			long nSize = Convert.ToInt64(sSize, 10 );

			if ( nSize <= 0L ) 
			{
				throw new ImapException(ImapException.ImapErrorEnum.IMAP_ERR_INVALIDHEADER);
			}

			return nSize;
		}


        internal class IMAPFolder
        {
            public string FolderName { get; set; }
            public List<IMAPFolder> SubFolders { get; set; }
            public string ParentFolder { get; set; }

            public IMAPFolder(String name, String parent)
            {
                SubFolders = new List<IMAPFolder>();
                FolderName = name;
                ParentFolder = parent;
            }

            public override string ToString()
            {
                return FolderName;
            }
        }
	}
    
}
