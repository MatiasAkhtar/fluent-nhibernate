﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.MappingModel.Identity;
using FluentNHibernate.MappingModel;

namespace FluentNHibernate.Conventions.Instances
{
    public class CompositeIdentityInstance : CompositeIdentityInspector, ICompositeIdentityInstance
    {
        private readonly CompositeIdMapping mapping;
        private bool nextBool = true;


        public CompositeIdentityInstance(CompositeIdMapping mapping)
            : base(mapping)
        {
            this.mapping = mapping;
        }


        public new void UnsavedValue(string unsavedValue)
        {
            if (!mapping.IsSpecified("UnsavedValue"))
                mapping.UnsavedValue = unsavedValue;
        }

        public new IAccessInstance Access
        {
            get
            {
                return new AccessInstance(value =>
                {
                    if (!mapping.IsSpecified("Access"))
                        mapping.Access = value;
                });
            }
        }

        public new void Mapped()
        {
            if (!mapping.IsSpecified("Mapped"))
                mapping.Mapped = nextBool;
            nextBool = true;
        }

        public ICompositeIdentityInstance Not
        {
            get
            {
                nextBool = !nextBool;
                return this;
            }
        }
    }
}
