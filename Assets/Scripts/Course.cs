
[System.Serializable]
public class Course{
        public string code = "";
        public double credit = 0;
        public string title = "";

        public Course(){
        }

        public Course(string code, double credit, string title){
            this.code = code;
            this.credit = credit;
            this.title = title;
        }
    }
