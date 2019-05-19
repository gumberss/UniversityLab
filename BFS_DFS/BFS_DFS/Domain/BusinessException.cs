using System;

namespace BFS_DFS.Domain
{
    public class BusinessException : Exception
    {
        public BusinessException(String message) : base(message) { }
    }
}
