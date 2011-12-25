using System;
using designPatterns.model;
using designPatterns.model.Behavioural;

namespace designPatterns.viewmodel
{
    public class HandlerViewModel: ViewModel<HandlerModel>
    {

        public Job Job { get; set; }

        public HandlerViewModel(Model model) : base(model as HandlerModel) {
        }

        public HandlerViewModel() {
            Model = new HandlerModel();
            Job = new Job();
        }

        public String AddJob() {
            var model = Model;
            return model.AddJob(Job) + Environment.NewLine;
        }

        #region Data for binding
        public string DirectorName { 
            get { return Model.Director.Name; }
            set {
                if (Model.Director.Name.Equals(value)) return;
                Model.Director.Name = value;
                OnPropertyChanged("DirectorName");
            }
        }

        public string ProjectManagerName { 
            get { return Model.ProjectManager.Name; }
            set {
                if (Model.ProjectManager.Name.Equals(value)) return;
                Model.ProjectManager.Name = value;
                OnPropertyChanged("ProjectManagerName");
            }
        }

        public string ViceDirectorName { 
            get { return Model.ViceDirector.Name; }
            set {
                if (Model.ViceDirector.Name.Equals(value)) return;
                Model.ViceDirector.Name = value;
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
