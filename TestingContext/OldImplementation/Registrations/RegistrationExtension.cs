﻿namespace TestingContextCore.OldImplementation.Registrations
{
    using TestingContextCore.OldImplementation.Filters;
    using TestingContextCore.OldImplementation.Providers;

    internal static class RegistrationExtension
    {
        public static void RegisterFilter(this RegistrationStore store, IFilter filter, string key = null)
        {
            PreRegister(store);
            store.Filters.Add(filter);
        }

        public static void RegisterProvider(this RegistrationStore store, Definition definition, IProvider provider)
        {
            PreRegister(store);
            store.Providers[definition] = provider;
        }

        public static void RegisterFilterInversion(this RegistrationStore store, string filterKey)
        {
            PreRegister(store);
            store.FilterInversions.Add(filterKey);
        }

        public static void RegisterItemValidityInversion(this RegistrationStore store, Definition definition)
        {
            PreRegister(store);
            store.ItemInversions.Add(definition);
        }

        public static void RegisterCollectionValidityInversion(this RegistrationStore store, Definition definition)
        {
            PreRegister(store);
            store.CollectionInversions.Add(definition);
        }

        private static void PreRegister(RegistrationStore store)
        {
            store.Tree = null; // next resolution will produce new tree might consider throwing an exception
        }
    }
}