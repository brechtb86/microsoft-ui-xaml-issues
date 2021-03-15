using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinUI3Issues.Models;

namespace WinUI3Issues.ViewModels
{
    public class ItemsRepeaterScrollIssueViewModel : BaseViewModel
    {
        public ObservableCollection<DummyObject> DummyObjects { get; set; }

        public ItemsRepeaterScrollIssueViewModel()
        {
            this.DummyObjects = new ObservableCollection<DummyObject>();

            for (var i = 1; i <= 100; i++)
            {
                this.DummyObjects.Add(new DummyObject(){ Name = $"Object_{i}"});
            }
        }
    }
}
