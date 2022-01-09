using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Programm
    {
        public class Notebook
        {
            public string CoverMaterial { get; set; }
            public string MainColors { get; set; }
            public string Width { get; set; }

            public void ShowNotebook()
            {
                Console.WriteLine("Cover Material : " + CoverMaterial);
                Console.WriteLine("Main colors: " + MainColors);
                Console.WriteLine("Width: " + Width);
            }
        }

        public abstract class NotebookBuilder
        {
            protected Notebook NotebookObject;
            public abstract void SetCoverMaterial();
            public abstract void SetMainColors();
            public abstract void SetWidth();
            public void CreateNewNotebook()
            {
                NotebookObject = new Notebook();
            }
            public Notebook GetNotebook()
            {
                return NotebookObject;
            }
        }

        public class Director
        {
            public Notebook MakeNotebook(NotebookBuilder notebook)
            {
                notebook.CreateNewNotebook();
                notebook.SetCoverMaterial();
                notebook.SetMainColors();
                notebook.SetWidth();

                return notebook.GetNotebook();
            }
        }

        class Diary : NotebookBuilder
        {
            public override void SetCoverMaterial()
            {
                NotebookObject.CoverMaterial = "Beautiful picture or leather/wooden cover";
            }
            public override void SetMainColors()
            {
                NotebookObject.MainColors = "Any colors";
            }
            public override void SetWidth()
            {
                NotebookObject.Width = "48 sheets or more";
            }
        }

        class Copybook : NotebookBuilder
        {
            public override void SetCoverMaterial()
            {
                NotebookObject.CoverMaterial = "Paper of any density";
            }
            public override void SetMainColors()
            {
                NotebookObject.MainColors = "Mostly solid colors";
            }
            public override void SetWidth()
            {
                NotebookObject.Width = "12/18/24/48/96 sheets";
            }
        }

        static void Main(string[] args)
        {
            //Builder
            Notebook notebook;
            Director director = new Director();
            Diary diary = new Diary();
            notebook = director.MakeNotebook(diary);
            notebook.ShowNotebook();
            Console.WriteLine("\n");
            Copybook copybook = new Copybook();
            notebook = director.MakeNotebook(copybook);
            notebook.ShowNotebook();
        }
    }

}