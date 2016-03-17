// Copyright (c) Aspose 2002-2016. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GroupDocsViewerVisualStudioPlugin.Core
{
    public class GroupDocsComponents
    {
        public static Dictionary<String, GroupDocsComponent> list = new Dictionary<string, GroupDocsComponent>();
        public GroupDocsComponents()
        {
            list.Clear();

            GroupDocsComponent groupdocsViewer = new GroupDocsComponent();
            groupdocsViewer.set_downloadUrl("");
            groupdocsViewer.set_downloadFileName("groupdocs.viewer.zip");
            groupdocsViewer.set_name(Constants.GROUPDOCS_COMPONENT);
            groupdocsViewer.set_remoteExamplesRepository("https://github.com/groupdocsviewer/GroupDocs_Viewer_NET.git");
            list.Add(Constants.GROUPDOCS_COMPONENT, groupdocsViewer);
        }
    }
}
