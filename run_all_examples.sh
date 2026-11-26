#!/bin/bash
echo "Running GroupDocs.Viewer for .NET Examples..."
echo
echo "Choose a runner:"
echo "  1. Framework (net462)"
echo "  2. Net (net10.0)"
echo "  3. NetWindows (net10.0-windows7.0)"
echo
read -p "Enter choice (default=2): " choice
case "$choice" in
    1) PROJ="Examples/GroupDocs.Viewer.Examples.CSharp.Framework/GroupDocs.Viewer.Examples.CSharp.Framework.csproj" ;;
    2) PROJ="Examples/GroupDocs.Viewer.Examples.CSharp.Net/GroupDocs.Viewer.Examples.CSharp.Net.csproj" ;;
    3) PROJ="Examples/GroupDocs.Viewer.Examples.CSharp.NetWindows/GroupDocs.Viewer.Examples.CSharp.NetWindows.csproj" ;;
    *) PROJ="Examples/GroupDocs.Viewer.Examples.CSharp.Net/GroupDocs.Viewer.Examples.CSharp.Net.csproj" ;;
esac
dotnet run --project "$PROJ"
