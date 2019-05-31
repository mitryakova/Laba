﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba.Models
{
    public class MemCache : IStorage<Lab1Data>
    {
        private object _sync = new object();
        private List<Lab1Data> _memCache = new List<Lab1Data>();
        public Lab1Data this[Guid id]
        {
            get
            {
                lock (_sync)
                {
                    if (!Has(id)) throw new IncorrectLab1DataException($"No LabData with id {id}");

                    return _memCache.Single(x => x.Id == id);
                }
            }
            set
            {
                if (id == Guid.Empty) throw new IncorrectLab1DataException("Cannot request LabData with an empty id");

                lock (_sync)
                {
                    if (Has(id))
                    {
                        RemoveAt(id);
                    }

                    value.Id = id;
                    _memCache.Add(value);
                }
            }
        }

        public System.Collections.Generic.List<Lab1Data> All => _memCache.Select(x => x).ToList();

        public void Add(Lab1Data value)
        {
            if (value.Id != Guid.Empty) throw new IncorrectLab1DataException($"Cannot add value with predefined id {value.Id}");

            value.Id = Guid.NewGuid();
            this[value.Id] = value;
        }

        public bool Has(Guid id)
        {
            return _memCache.Any(x => x.Id == id);
        }

        public void RemoveAt(Guid id)
        {
            lock (_sync)
            {
                _memCache.RemoveAll(x => x.Id == id);
            }
        }
    }
}
