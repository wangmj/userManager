using System;

namespace wmj.userManagerServer.Domain.Models
{
    public class BaseEntity<T>
    {
        public T Id { get;set;}
        public DateTime CreateTime { get;set;}
    }
}
