//using System;
//using System.Reflection;
//using FluentEvaluator.Conjunctions;

//namespace FluentEvaluator.Actions
//{
//    public class OtherwiseAction
//    {
//        public OtherwiseAction(bool evaluationToPerform, Action actionToPerformAfterEvaluation)
//        {
//            EvaluationToPerform = evaluationToPerform;
//            ActionToPerformAfterEvaluation = actionToPerformAfterEvaluation;
//        }

//        protected Action ActionToPerformAfterEvaluation
//        {
//            get;
//            set;
//        }

//        protected bool EvaluationToPerform
//        {
//            get;
//            set;
//        }

//        public virtual OtherwiseWhen When
//        {
//            get
//            {
//                return new OtherwiseWhen(EvaluationToPerform);
//            }
//        }

//        public EvaluationConclusion ThrowAnException<ExceptionType>(params object[] exceptionArguments) where ExceptionType : Exception
//        {
//            Action otherwiseActionToPerform = () =>
//                                                {
//                                                    ConstructorInfo currentCtorInfo = typeof(ExceptionType).GetConstructor(EvaluationUtilities.GetConstructorTypes(exceptionArguments));

//                                                    if (currentCtorInfo != null)
//                                                        throw (ExceptionType)currentCtorInfo.Invoke(exceptionArguments);
//                                                };
//            return new EvaluationConclusion(EvaluationToPerform, ActionToPerformAfterEvaluation, otherwiseActionToPerform);
//        }

//        public EvaluationConclusion DoThis(Action actionToPerform)
//        {
//            Action otherwiseActionToPerform = actionToPerform;
//            return new EvaluationConclusion(EvaluationToPerform, ActionToPerformAfterEvaluation, otherwiseActionToPerform);
//        }
//    }
//}