﻿using System;
using EPubLibrary.PathUtils;
using EPubLibraryContracts;

namespace EPubLibrary.ReferenceUtils
{
    public static class ReferencesUtils
    {
        /// <summary>
        /// Check if reference is external reference
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static bool IsExternalLink(string link)
        {
            if (link.Contains(@"://"))
            {
                return true;
            }
            if (link.StartsWith("mailto:"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if anchor reference is internal or external
        /// </summary>
        /// <param name="link">link/reference to check</param>
        /// <returns>returns true if internal, false otherwise</returns>
        public static bool IsInternalLink(string link)
        {
            if ((link.Length > 0) && link.StartsWith("#"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns ID substring from the link reference string
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static string GetIdFromLink(string link)
        {
            int position = link.IndexOf("#", StringComparison.Ordinal);
            if ( position == -1 || (position + 1 == link.Length) )
            {
                return link;
            }
            return link.Substring(position+1);
        }


        public static string FormatImagePath(string validName, bool flatStructure)
        {
            EPubInternalPath imagePath = new EPubInternalPath(EPubInternalPath.GetDefaultLocation(DefaultLocations.DefaultImagesFolder), validName);
            return imagePath.GetRelativePath(EPubInternalPath.GetDefaultLocation(DefaultLocations.DefaultTextFolder), flatStructure);
        }
    }
}
