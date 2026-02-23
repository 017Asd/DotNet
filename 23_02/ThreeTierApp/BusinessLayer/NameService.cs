using DataAccessLayer;
using System.Linq;

namespace BusinessLayer
{
    public class NameService
    {
        private readonly NameRepository _repo;

        public NameService()
        {
            _repo = new NameRepository();
        }

        public List<string> GetReversedNames(List<string> inputNames)
        {
            var names = _repo.GetNames(inputNames);

            return names
                .Select(name => string.Concat(name.Reverse()))
                .ToList();
        }
    }
}