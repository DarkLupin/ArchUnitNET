﻿using ArchUnitNET.Domain;

namespace ArchUnitNET.Fluent
{
    public class ComplexCondition<TRuleType, TReferenceType> : ICondition<TRuleType>
        where TRuleType : ICanBeAnalyzed where TReferenceType : ICanBeAnalyzed
    {
        private readonly IPredicate<TReferenceType> _predicate;
        private readonly RelationCondition<TRuleType, TReferenceType> _relation;

        public ComplexCondition(RelationCondition<TRuleType, TReferenceType> relation,
            IPredicate<TReferenceType> predicate)
        {
            _relation = relation;
            _predicate = predicate;
        }

        public string Description => _relation.Description + " " + _predicate.Description;

        public string FailDescription => _relation.FailDescription + " " + _predicate.Description;

        public ConditionResult Check(TRuleType obj, Architecture architecture)
        {
            return new ConditionResult(_relation.CheckRelation(obj, _predicate, architecture), FailDescription);
        }

        public bool CheckEmpty()
        {
            return true;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}