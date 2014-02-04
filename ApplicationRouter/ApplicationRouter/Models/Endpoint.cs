
using System.Security.Policy;

namespace ApplicationRouter.Models
{
    public class Endpoint
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string URL { get; set; }

        protected bool Equals(Endpoint other)
        {
            return string.Equals(Name, other.Name) && string.Equals(Version, other.Version) && string.Equals(URL, other.URL);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Version != null ? Version.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (URL != null ? URL.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Endpoint) obj);
        }

        public override string ToString()
        {
            return string.Format("Endpoint Name [{0}], URL [{1}], Version [{2}]",
                Name, URL, Version);
        }
    }
}
