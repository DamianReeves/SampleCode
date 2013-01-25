using System;

namespace DamianReeves.Simple.Spreadsheets {
    public class SymbolTableEntry : ICloneable {
        private readonly Guid _id;
        private readonly Type _type;
        private readonly string _name;
        private readonly Guid _scope;

        public SymbolTableEntry(Type type) {
            
        }

        public SymbolTableEntry(Type type, string name, Guid scope) {
            if (type == null) throw new ArgumentNullException("type");
            _type = type;
            _name = name;
            _scope = scope;
            _id = Guid.NewGuid();
        }

        private SymbolTableEntry(SymbolTableEntry other) {
            if (other == null) throw new ArgumentNullException("other");
            _type = other.Type;
            _name = other.Name;
            _scope = other._scope;
            _id = other._id;
        }

        public Guid Id {
            get { return _id; }
        }

        public Type Type {
            get { return _type; }
        }

        public string Name {
            get { return _name; }
        }

        public Guid Scope {
            get { return _scope; }
        }

        public object Clone() {
            return new SymbolTableEntry(this);
        }
    }
}