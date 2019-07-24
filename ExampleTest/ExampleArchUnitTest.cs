/*
 * Copyright 2019 TNG Technology Consulting GmbH
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Collections.Generic;
using System.Linq;
using ArchUnitNET.Core;
using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using Xunit;

// ReSharper disable UnusedMember.Global

namespace ExampleTest
{
    public class ExampleArchUnitTest
    {
        // TIP: load your architecture once at the start to maximize performance of your tests
        private static readonly Architecture ChefArchitecture =
            new ArchLoader().LoadAssembly(typeof(FrenchChef).Assembly).Build();
        // replace <FrenchChef> with a class from your architecture

        // declare variables you'll use throughout your tests up here
        private readonly IEnumerable<Class> _chefs;
        private readonly Interface _cookInterface;

        // initialize your test variables in the constructor
        // TIP: access types of values from your architecture, then filter them using provided extension methods
        public ExampleArchUnitTest()
        {
            _chefs = ChefArchitecture.Classes.Where(cls => cls.NameEndsWith("Chef"));
            _cookInterface = ChefArchitecture.GetInterfaceOfType(typeof(ICook));
        }

        [Fact]
        public void AllChefsCook()
        {
            Assert.All(_chefs, chef => chef.Implements(_cookInterface));
        }
    }


    public class FrenchChef : ICook
    {
        private string _name;
        private int _age;

        public FrenchChef(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public void Cook()
        {
            CremeBrulee();
            Crepes();
            Ratatouille();
        }

        private static void CremeBrulee()
        {
        }

        private static void Crepes()
        {
        }

        private static void Ratatouille()
        {
        }
    }

    public class ItalianChef : ICook
    {
        private string _name;
        private int _age;

        public ItalianChef(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public void Cook()
        {
            PizzaMargherita();
            Tiramisu();
            Lasagna();
        }

        private static void PizzaMargherita()
        {
        }

        private static void Tiramisu()
        {
        }

        private static void Lasagna()
        {
        }
    }

    public interface ICook
    {
        void Cook();
    }
}