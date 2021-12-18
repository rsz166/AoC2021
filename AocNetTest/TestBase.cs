using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AocNetTest
{
    public abstract class TestBase<T> where T : new()
    {
        protected string FilePath => string.Format("../../../files/{0}.txt", typeof(T).Name.ToLower());

        protected T GetSolver() => new();

        protected string GetFinalInput() => File.ReadAllText(FilePath);
    }
}
