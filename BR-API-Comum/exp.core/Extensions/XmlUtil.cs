using System.Linq;
using System.Xml.Linq;

namespace Exp.Core.Extensions
{
    public class XmlUtil
    {
        public static string RemoveAllNamespaces(string xmlDocument)
        {
            var xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(xmlDocument));

            return xmlDocumentWithoutNs.ToString();
        }

        private static XElement RemoveAllNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {
                var xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;

                foreach (var attribute in xmlDocument.Attributes())
                    xElement.Add(attribute);

                return xElement;
            }

            return new XElement(xmlDocument.Name.LocalName,
                xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
        }

        public static string RemoveSoapEnvelope(string _xml)
        {
            /*
            Removendo o conteudo do envelope
            */
            var prefix = "soap";
            var soapEnvelopeXml = string.Empty;
            int iSoapBodyStartIndex;
            int iSoapBodyEndIndex;
            //find soap body start index
            var iSoapBodyElementStartFrom = _xml.IndexOf("<" + prefix + ":Body");
            var iSoapBodyElementStartEnd = _xml.IndexOf(">", iSoapBodyElementStartFrom);
            iSoapBodyStartIndex = iSoapBodyElementStartEnd + 1;
            //find soap body end index
            iSoapBodyEndIndex = _xml.IndexOf("</" + prefix + ":Body>") - 1;
            //get soap body (XML data)

            soapEnvelopeXml = _xml.Substring(iSoapBodyStartIndex, iSoapBodyEndIndex - iSoapBodyStartIndex + 1);

            var RetornouXML = soapEnvelopeXml.IndexOf("<?xml");
            if (RetornouXML < 0) soapEnvelopeXml = "<?xml version=\"1.0\"?>" + soapEnvelopeXml;

            return soapEnvelopeXml;
        }

        public static string RemoveSoapEnvelopeRafael(string _xml)
        {
            /*
            Removendo o conteudo do envelope
            */
            var prefix = "DetalhesPlanosResponse";
            var soapEnvelopeXml = string.Empty;
            int iSoapBodyStartIndex;
            int iSoapBodyEndIndex;
            //find soap body start index
            var iSoapBodyElementStartFrom = _xml.IndexOf("<" + prefix + "");
            var iSoapBodyElementStartEnd = _xml.IndexOf(">", iSoapBodyElementStartFrom);
            iSoapBodyStartIndex = iSoapBodyElementStartEnd + 1;
            //find soap body end index
            iSoapBodyEndIndex = _xml.IndexOf("</" + prefix + ">") - 1;
            //get soap body (XML data)

            soapEnvelopeXml = _xml.Substring(iSoapBodyStartIndex, iSoapBodyEndIndex - iSoapBodyStartIndex + 1);

            var RetornouXML = soapEnvelopeXml.IndexOf("<?xml");
            if (RetornouXML < 0) soapEnvelopeXml = "<?xml version=\"1.0\"?>" + soapEnvelopeXml;

            return soapEnvelopeXml;
        }
    }
}