using System;

namespace designPatterns.model.Behavioural
{
    public class HandlerModel : Model
    {
        public Director Director { get; set; }
        public ViceDirector ViceDirector { get; set; }
        public ProjectManager ProjectManager { get; set; }

        /// <summary>
        /// Constructor from base
        /// </summary>
        public HandlerModel() {
            Description = "Handler pattern" + Environment.NewLine + Environment.NewLine+ Environment.NewLine +
                          "Giám đốc sẽ xử lý các công việc với giá trị trên 500" + Environment.NewLine +
                          "Phó Giám đốc sẽ xử lý các công việc với giá trị từ 100 đến 500" + Environment.NewLine +
                          "Quản lý dự án sẽ xử lý các công việc với giá trị từ 0 đến 100" + Environment.NewLine;
            Director = new Director("Dũng");
            ViceDirector = new ViceDirector("Huy");
            ProjectManager = new ProjectManager("Phương");

            ProjectManager.HigherMember = ViceDirector;
            ViceDirector.HigherMember = Director;
        }
        
        public string AddJob(Job job) {
            return ProjectManager.Process(job);
        }
    }

    #region Handler pattern code behind the scene

    /// <summary>
    /// abstract class representing all company member
    /// </summary>
    public abstract class Member {

        public string Name { get; set; }
        protected float LimitedPrice;
        public Member HigherMember { get; set; }

        protected Member(string name) {
            Name = name;
        }

        /// <summary>
        /// Process an incoming job
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public virtual string Process(Job job) {
            if (job.Price < LimitedPrice) {
                var output = Name + " đang xử lý công việc: " + Environment.NewLine;
                output += "#Mô tả: " + job.Description + Environment.NewLine;
                output += "#Trị giá: " + job.Price + Environment.NewLine;
                return output;
            }
            return HigherMember.Process(job);
        }
    }

    /// <summary>
    /// Director 
    /// </summary>
    public class Director: Member {
        public Director(string name) : base(name) {
            LimitedPrice = float.MaxValue;
        }
    }

    /// <summary>
    /// Vice Director
    /// </summary>
    public class ViceDirector : Member {
        public ViceDirector(string name) : base(name) {
            LimitedPrice = 500;
        }
    }

    /// <summary>
    /// Project Manager
    /// </summary>
    public class ProjectManager: Member {
        public ProjectManager(string name) : base(name) {
            LimitedPrice = 200;
        }
    }

    /// <summary>
    /// A Job Representation
    /// </summary>
    public class Job {
        public string Description { get; set; }
        public float Price { get; set; }

        public Job(string description, float price) {
            Description = description;
            Price = price;
        }

        public Job() {
            Description = "";
            Price = 1;
        }
    }

    #endregion
}
