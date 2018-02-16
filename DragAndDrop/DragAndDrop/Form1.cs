using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace DragAndDrop
{
    public partial class Form1 : Form
    {
        TextWriterTraceListener debugWriter = new TextWriterTraceListener("trace.log");

        /// <summary>
        /// This is a nested class.
        /// </summary>
        class videoInfo
        {
            public string videoUrl { get; set; }
        }

        videoInfo videoData = new videoInfo();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {

        }

        /// <summary>
        /// This method is triggered when the user releases the drag when over the panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            //Setting the data type.
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //storing the file into a files array.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                //Storing the video string into the video object.
                videoData.videoUrl = files.FirstOrDefault();

                //Making sure that the video string is not empty.
                if (!string.IsNullOrWhiteSpace(videoData.videoUrl))
                {
                    //Getting the url of the video and playing it in the media player.
                    axWindowsMediaPlayer1.URL = videoData.videoUrl;
                    debugWriter.WriteLine($"{videoData.videoUrl.ToString()} Log Success");
                    debugWriter.Flush();
                }
            }
        }

        /// <summary>
        /// This method is for when the mouse is dragging something and it enters over the panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            //The drag and drop effects.
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
                
            }
        }
    }
}
