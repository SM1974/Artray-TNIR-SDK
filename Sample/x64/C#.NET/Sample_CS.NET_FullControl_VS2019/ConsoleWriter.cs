using System;
using System.Collections.Generic;
using System.Text;
using System.IO; // Added by sfm36
using System.Windows.Forms; // Added by sfm36

// Tutorial at https://saezndaree.wordpress.com/2009/03/29/how-to-redirect-the-consoles-output-to-a-textbox-in-c/
// However, the code below was written by Peter Christopher

/*
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
*/


namespace Sample_CS
{
    public class ConsoleWriter : TextWriter
    {
        private Control textbox;
        public ConsoleWriter(Control textbox)
        {
            this.textbox = textbox;
        }

        public override void Write(char value)
        {
            if (textbox.InvokeRequired)
            {
                textbox.Invoke(new MethodInvoker(() => textbox.Text += value));
            }
            else
            {
                textbox.Text += value;
            }
        }

        public override void Write(string value)
        {
            if (textbox.InvokeRequired)
            {
                textbox.Invoke(new MethodInvoker(() => textbox.Text += value));
            }
            else
            {
                textbox.Text += value;
            }
        }

        public override Encoding Encoding
        {
            get { return Encoding.ASCII; }
        }
    }
}
