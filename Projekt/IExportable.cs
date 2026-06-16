using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    public interface IExportable
    {
        string ExportToHTML();

        string ExportToTXT();

        string ExportToXML();
    }
}
