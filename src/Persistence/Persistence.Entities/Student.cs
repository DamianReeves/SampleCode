using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities {
    [DataContract]
    public class Student {
        [DataMember]
        public int StudentId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
    }

    [DataContract]
    public class Class {
        public int ClassId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public IList<ClassMember> Members { get; set; }
    }

    [DataContract]
    public class ClassMember {
        public int ClassMemberId { get; set; }
        public int ClassId { get; set; }
        public int StudentId { get; set; }
        public virtual Class Class { get; set; }
        public virtual Student Student { get; set; }
    }
}
