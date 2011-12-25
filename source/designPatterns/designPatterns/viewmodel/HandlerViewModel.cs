using System;
using designPatterns.model;
using designPatterns.model.Behavioural;

namespace designPatterns.viewmodel
{
    public class HandlerViewModel: ViewModel
    {

        public Job Job { get; set; }

        public HandlerViewModel(Model model) : base(model) {
            Model = new HandlerModel();
            Job = new Job();
        }

        public HandlerViewModel() {
        }

        public String AddJob() {
            var model = (HandlerModel) Model;
            return model.AddJob(Job) + Environment.NewLine;
        }

        #region Data for binding
        public string DirectorName { 
            get { return ((HandlerModel)Model).Director.Name; }
            set {
                if (((HandlerModel)Model).Director.Name.Equals(value)) return;
                ((HandlerModel)Model).Director.Name = value;
                OnPropertyChanged("DirectorName");
            }
        }

        public string ProjectManagerName { 
            get { return ((HandlerModel)Model).ProjectManager.Name; }
            set {
                if (((HandlerModel)Model).ProjectManager.Name.Equals(value)) return;
                ((HandlerModel)Model).ProjectManager.Name = value;
                OnPropertyChanged("ProjectManagerName");
            }
        }

        public string ViceDirectorName { 
            get { return ((HandlerModel)Model).ViceDirector.Name; }
            set {
                if (((HandlerModel)Model).ViceDirector.Name.Equals(value)) return;
                ((HandlerModel)Model).ViceDirector.Name = value;
                OnPropertyChanged("ViceDirectorName");
            }
        }

        public string JobDescription
        {
            get { return Job.Description; }
            set
            {
                if (Job.Description.Equals(value)) return;
                Job.Description = value;
                OnPropertyChanged("JobDescription");
            }
        }

        public float JobPrice
        {
            get { return Job.Price; }
            set
            {
                if (Job.Price.Equals(value)) return;
                Job.Price = value;
                OnPropertyChanged("JobPrice");
            }
        }

        #endregion
    }
}
