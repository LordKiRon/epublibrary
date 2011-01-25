﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace EPubLibrary.Content.Spine
{
    internal class SpineSection : List<SpineItem>
    {
        private readonly XNamespace opfNameSpace = @"http://www.idpf.org/2007/opf";

        public XElement GenerateSpineElement()
        {
            XElement spineElement = new XElement(opfNameSpace + "spine");
            spineElement.Add(new XAttribute("toc", "ncx"));

            foreach (var spineItem in this)
            {
                XElement itemref = new XElement(opfNameSpace + "itemref");
                itemref.Add(new XAttribute("idref", spineItem.Name));
                spineElement.Add(itemref);
            }
            return spineElement;
        }
    }
}