using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Reflection;

namespace CodeGenerator.Back.Schema
{
    public partial class XSDTreeView : TreeView
    {
        #region --[enums]--
        enum TreeViewImages 
        { 
            Schema, 
            Element, 
            SimpleType, 
            ComplexType, 
            Annotation, 
            Documentation, 
            AppInfo, 
            Attribute, 
            Facet 
        };
        #endregion

        #region --[constructor]--
        public XSDTreeView()
        {
           

            InitializeComponent();
        }
        #endregion

        #region --[private members]--
        List<GlobalElementComplexType> _ComplexTypes;
        #endregion

        #region --[private methods]--
        private void CreateRootNode()
        {
            // Limpia todos los nodos.
            this.Nodes.Clear();

            // Crea un nodo raiz.
            TreeNode wRootNode = new TreeNode("Schema:");
            wRootNode.ImageIndex = (int)TreeViewImages.Schema;
            wRootNode.SelectedImageIndex = (int)TreeViewImages.Schema;
            this.Nodes.Add(wRootNode);
        }

        private void DecodeSchema(XmlSchema pSchema, TreeNode pNode)
        {
            try
            {
                _ComplexTypes = new List<GlobalElementComplexType>();
                DecodeSchemaRecursive(pSchema, pNode);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        private TreeNode DecodeSchemaRecursive(XmlSchemaObject pObj, TreeNode pNode)
        {
            TreeNode wNewNode = pNode;
            XmlSchemaAnnotation annot = pObj as XmlSchemaAnnotation;
            XmlSchemaAttribute attrib = pObj as XmlSchemaAttribute;
            XmlSchemaFacet facet = pObj as XmlSchemaFacet;
            XmlSchemaDocumentation doc = pObj as XmlSchemaDocumentation;
            XmlSchemaAppInfo appInfo = pObj as XmlSchemaAppInfo;
            XmlSchemaElement element = pObj as XmlSchemaElement;
            XmlSchemaSimpleType simpleType = pObj as XmlSchemaSimpleType;
            XmlSchemaComplexType complexType = pObj as XmlSchemaComplexType;

            #region --[Annotation]--
            if (annot != null)
            {
                wNewNode = new TreeNode("--annotation--");
                wNewNode.ImageIndex = 4;
                wNewNode.SelectedImageIndex = 4;
                pNode.Tag = "ANNOTATION";
                pNode.Nodes.Add(wNewNode);
                foreach (XmlSchemaObject schemaObject in annot.Items)
                {
                    DecodeSchemaRecursive(schemaObject, wNewNode);
                }
            }
            #endregion

            #region --[Attribute]--
            if (attrib != null)
            {
                wNewNode = new TreeNode(attrib.QualifiedName.Name);
                wNewNode.ImageIndex = 7;
                wNewNode.SelectedImageIndex = 7;
                pNode.Tag = "ATTRIBUTE";
                pNode.Nodes.Add(wNewNode);
            }
            #endregion

            #region --[Facet]--
            if (facet != null)
            {
                wNewNode = new TreeNode(facet.ToString());
                wNewNode.ImageIndex = 8;
                wNewNode.SelectedImageIndex = 8;
                pNode.Tag = "FACET";
                pNode.Nodes.Add(wNewNode);
            }
            #endregion

            #region --[Documentation]--
            if (doc != null)
            {
                wNewNode = new TreeNode("--documentation--");
                wNewNode.ImageIndex = 5;
                wNewNode.SelectedImageIndex = 5;
                pNode.Tag = "DOCUMENTATION";
                pNode.Nodes.Add(wNewNode);
            }
            #endregion

            #region --[App Info]--
            if (appInfo != null)
            {
                wNewNode = new TreeNode("--app info--");
                wNewNode.ImageIndex = 6;
                wNewNode.SelectedImageIndex = 6;
                pNode.Tag = "APP INFO";
                pNode.Nodes.Add(wNewNode);
            }
            #endregion

            #region --[Element]--
            if (element != null)
            {
                XmlSchemaSimpleType st = element.SchemaType as XmlSchemaSimpleType;
                XmlSchemaComplexType ct = element.SchemaType as XmlSchemaComplexType;
                
                if (st != null)
                {
                    // este es un elemento Simple Type.  e.j (int, string, etc)
                    TreeNode node2 = DecodeSchemaRecursive(st, wNewNode);
                    node2.Text = element.Name;
                }
                else if (ct != null)
                {
                    // este es un elemento Complex Type.  e.j (Cliente, forma de pago, etc)
                    ct.Name = element.Name;
                    TreeNode node2 = DecodeSchemaRecursive(ct, wNewNode);
                    GlobalElementComplexType wGlobal = new GlobalElementComplexType(ct, element.MaxOccurs);
                    wGlobal.Name = element.Name;
                    node2.Tag = wGlobal;
                    _ComplexTypes.Add(wGlobal);
                 }
                else
                {
                    // Este es un elemento plano  (plain ol' fashioned element).
                    wNewNode = new TreeNode(element.QualifiedName.Name);
                    wNewNode.ImageIndex = 1;
                    wNewNode.SelectedImageIndex = 1;

                    #region --[GlobalElementType]--
                    switch (element.ElementSchemaType.Datatype.ValueType.ToString())
                    {
                        case "System.Boolean":
                            {
                                wNewNode.Tag = new GlobalElementType<bool?>(element);
                                break;
                            }
                        case "System.String":
                            {
                                wNewNode.Tag = new GlobalElementType<string>(element);
                                break;
                            }
                        case "System.Int32":
                            {
                                wNewNode.Tag = new GlobalElementType<int?>(element);
                                break;
                            }
                        case "System.Decimal":
                            {
                                wNewNode.Tag = new GlobalElementType<decimal?>(element);
                                break;
                            }
                        case "System.Double":
                            {
                                wNewNode.Tag = new GlobalElementType<Double?>(element);
                                break;
                            }
                        case "System.DateTime":
                            {
                                wNewNode.Tag = new GlobalElementType<DateTime?>(element);
                                break;
                            }
                        case "System.Byte[]":
                            {
                                wNewNode.Tag = new GlobalElementType<System.Byte[]>(element);
                                break;
                            }
                           
                    }
                    #endregion
                    pNode.Nodes.Add(wNewNode);
                }
            }
            #endregion

            #region --[SimpleType]--
            if (simpleType != null)
            {
                wNewNode = new TreeNode(simpleType.QualifiedName.Name);
                wNewNode.ImageIndex = 2;
                wNewNode.SelectedImageIndex = 2;
                pNode.Nodes.Add(wNewNode);
                XmlSchemaSimpleTypeRestriction rest = simpleType.Content as XmlSchemaSimpleTypeRestriction;
                if (rest != null)
                {
                    foreach (XmlSchemaFacet schemaObject in rest.Facets)
                    {
                        DecodeSchemaRecursive(schemaObject, wNewNode);
                    }
                }
            }
            #endregion

            #region --[ComplexType]--
            if (complexType != null)
            {
                wNewNode = pNode.Nodes.Add(complexType.Name, complexType.Name, 3, 3);
                XmlSchemaSequence seq = complexType.Particle as XmlSchemaSequence;
                
                if (seq != null)
                {
                    foreach (XmlSchemaObject schemaObject in seq.Items)
                    {
                        DecodeSchemaRecursive(schemaObject, wNewNode);
                    }
                }
            }
            #endregion

            #region --[Properties]--
            foreach (PropertyInfo property in pObj.GetType().GetProperties())
            {
                if (property.PropertyType.FullName == "System.Xml.Schema.XmlSchemaObjectCollection")
                {
                    XmlSchemaObjectCollection childObjectCollection = (XmlSchemaObjectCollection)property.GetValue(pObj, null);
                    foreach (XmlSchemaObject schemaObject in childObjectCollection)
                    {
                        DecodeSchemaRecursive(schemaObject, wNewNode);
                    }
                }
            }
            #endregion
            
            return wNewNode;
        }

        private void SchemaValidationHandler(object sender, ValidationEventArgs e)
        {
        }
        #endregion

        #region --[public methods]--
        public void LoadSchemaByName(string pXSDFileName)
        {
           
            try
            {
                
                // Declaraciones.
                //XmlSchemaSet wSchemaSet = new XmlSchemaSet();
                //XmlSchema wSchema = new XmlSchema();
                
                // Carga de stream reader y schema a partir de archivo XSD.
                StreamReader wStreamReader = new StreamReader(pXSDFileName);
                LoadSchema(wStreamReader.BaseStream);
                //wSchema = XmlSchema.Read(wStreamReader, new ValidationEventHandler(SchemaValidationHandler));

                //wStreamReader.BaseStream.Position = 0;
                //this.Tag = wStreamReader.ReadToEnd();
                //wStreamReader.Close();

                //// Compilacion de schema.
                //wSchemaSet.Add(wSchema);
                //wSchemaSet.Compile();

                //// Carga de treeview.
                //CreateRootNode();
                //DecodeSchema(wSchema, this.Nodes[0]);
                //this.ExpandAll();
                //this.FullRowSelect = true;
                
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public void LoadSchema(Stream pStream)
        {
            try
            {

                // Declaraciones.
                XmlSchemaSet wSchemaSet = new XmlSchemaSet();
                XmlSchema wSchema = new XmlSchema();

                // Carga de stream reader y schema a partir de archivo XSD.

                wSchema = XmlSchema.Read(pStream, new ValidationEventHandler(SchemaValidationHandler));

                pStream.Position = 0;
                StreamReader sreader = new StreamReader(pStream);
                this.Tag = sreader.ReadToEnd();
                pStream.Close();

                // Compilacion de schema.
                wSchemaSet.Add(wSchema);
                wSchemaSet.Compile();

                // Carga de treeview.
                CreateRootNode();
                DecodeSchema(wSchema, this.Nodes[0]);
                this.ExpandAll();
                this.FullRowSelect = true;

            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public void GetComplexType(Stream pStream)
        {
            try
            {

                // Declaraciones.
                XmlSchemaSet wSchemaSet = new XmlSchemaSet();
                XmlSchema wSchema = new XmlSchema();

                // Carga de stream reader y schema a partir de archivo XSD.

                wSchema = XmlSchema.Read(pStream, new ValidationEventHandler(SchemaValidationHandler));

                pStream.Position = 0;
                StreamReader sreader = new StreamReader(pStream);
                this.Tag = sreader.ReadToEnd();
                pStream.Close();

                // Compilacion de schema.
                wSchemaSet.Add(wSchema);
                wSchemaSet.Compile();

                // Carga de treeview.
                CreateRootNode();
                DecodeSchema(wSchema, this.Nodes[0]);
                this.ExpandAll();
                this.FullRowSelect = true;

            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public string GetSchemaString()
        {
            if (this.Tag != null)
            {
                return this.Tag.ToString();
            }
            return String.Empty;
        }
        public List<GlobalElementComplexType> GetComplexTypes()
        {
            List<GlobalElementComplexType> wComplexTypeNames = new List<GlobalElementComplexType>();
            foreach (GlobalElementComplexType wCT in _ComplexTypes)
            {
                if (wCT.IncludeInDataSet == true)
                {
                    wCT.ChildElementsNames = GetElementNames(wCT.Name);
                    wCT.ChildElements = GetElement(wCT.Name);
                    wComplexTypeNames.Add(wCT);
                }
                int x = 1111;
               

            }
            return wComplexTypeNames;
        }
        public List<GlobalElementComplexType> GetAtributosProperties()
        {
            List<GlobalElementComplexType> wComplexTypeNames = new List<GlobalElementComplexType>();
            foreach (GlobalElementComplexType wCT in _ComplexTypes)
            {
                if (wCT.IncludeInDataSet == true)
                {
                    wCT.ChildElements = GetElement(wCT.Name);
                    wComplexTypeNames.Add(wCT);
                }
            }
            return wComplexTypeNames;
        }
        private List<string> GetElementNames(string pName)
        {
            List<string> wElementNames = new List<string>();
            TreeNode[] wNodes = this.Nodes.Find(pName, true);

            if (wNodes.Length > 0)
            {
                foreach (TreeNode wNode in wNodes[0].Nodes)
                {
                    if (wNode.Tag != null)
                    {
                        wElementNames.Add(wNode.Text);
                    }
                }
                if (wElementNames.Count > 0)
                {
                    return wElementNames;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
        private List<TreeNode> GetElement(string pName)
        {
            List<TreeNode> wAtributos = new List<TreeNode>();
            TreeNode[] wNodes = this.Nodes.Find(pName, true);

            if (wNodes.Length > 0)
            {
                foreach (TreeNode wNode in wNodes[0].Nodes)
                {
                    if (wNode.Tag != null)
                    {
                        wAtributos.Add(wNode);
                    }
                }
                if (wAtributos.Count > 0)
                {
                    return wAtributos;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
        #endregion
    }
}

