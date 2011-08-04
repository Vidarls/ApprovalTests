using System;
using System.Collections.Generic;
using System.Text;

namespace ApprovalTests.Combinations
{
    public class Approvals
    {
        private static readonly object[] EMPTY = {null};

        public static void ApproveAllCombinations<A>(Func<A, object> processCall, IEnumerable<A> aList)
        {
            ApproveAllCombinations((a, b, c, d, e, f, g, h, i) => processCall(a), "[{0}]", aList, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY);
        }

        public static void ApproveAllCombinations<A, B>(Func<A, B, object> processCall, IEnumerable<A> aList, IEnumerable<B> bList)
        {
            ApproveAllCombinations((a, b, c, d, e, f, g, h, i) => processCall(a, b), "[{0},{1}]", aList, bList, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY);
        }

        public static void ApproveAllCombinations<A, B, C>(Func<A, B, C, object> processCall, IEnumerable<A> aList, IEnumerable<B> bList, IEnumerable<C> cList)
        {
            ApproveAllCombinations((a, b, c, d, e, f, g, h, i) => processCall(a, b, c), "[{0},{1},{2}]", aList, bList, cList, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY);
        }

        public static void ApproveAllCombinations<A, B, C, D>(Func<A, B, C, D, object> processCall, IEnumerable<A> aList, IEnumerable<B> bList, IEnumerable<C> cList, IEnumerable<D> dList)
        {
            ApproveAllCombinations((a, b, c, d, e, f, g, h, i) => processCall(a, b, c, d), "[{0},{1},{2},{3}]", aList, bList, cList, dList, EMPTY, EMPTY, EMPTY, EMPTY, EMPTY);
        }

        public static void ApproveAllCombinations<A, B, C, D, E>(Func<A, B, C, D, E, object> processCall, IEnumerable<A> aList, IEnumerable<B> bList, IEnumerable<C> cList, IEnumerable<D> dList, IEnumerable<E> eList)
        {
            ApproveAllCombinations((a, b, c, d, e, f, g, h, i) => processCall(a, b, c, d, e), "[{0},{1},{2},{3},{4}]", aList, bList, cList, dList, eList, EMPTY, EMPTY, EMPTY, EMPTY);
        }

        public static void ApproveAllCombinations<A, B, C, D, E, F>(Func<A, B, C, D, E, F, object> processCall, IEnumerable<A> aList, IEnumerable<B> bList, IEnumerable<C> cList, IEnumerable<D> dList, IEnumerable<E> eList, IEnumerable<F> fList)
        {
            ApproveAllCombinations((a, b, c, d, e, f, g, h, i) => processCall(a, b, c, d, e, f), "[{0},{1},{2},{3},{4},{5}]", aList, bList, cList, dList, eList, fList, EMPTY, EMPTY, EMPTY);
        }

        public static void ApproveAllCombinations<A, B, C, D, E, F, G>(Func<A, B, C, D, E, F, G, object> processCall, IEnumerable<A> aList, IEnumerable<B> bList, IEnumerable<C> cList, IEnumerable<D> dList, IEnumerable<E> eList, IEnumerable<F> fList, IEnumerable<G> gList)
        {
            ApproveAllCombinations((a, b, c, d, e, f, g, h, i) => processCall(a, b, c, d, e, f, g), "[{0},{1},{2},{3},{4},{5},{6}]", aList, bList, cList, dList, eList, fList, gList, EMPTY, EMPTY);
        }

        public static void ApproveAllCombinations<A, B, C, D, E, F, G, H>(Func<A, B, C, D, E, F, G, H, object> processCall, IEnumerable<A> aList, IEnumerable<B> bList, IEnumerable<C> cList, IEnumerable<D> dList, IEnumerable<E> eList, IEnumerable<F> fList, IEnumerable<G> gList, IEnumerable<H> hList)
        {
            ApproveAllCombinations((a, b, c, d, e, f, g, h, i) => processCall(a, b, c, d, e, f, g, h), "[{0},{1},{2},{3},{4},{5},{6},{7}]", aList, bList, cList, dList, eList, fList, gList, hList, EMPTY);
        }

        public static void ApproveAllCombinations<A, B, C, D, E, F, G, H, I>(Func<A, B, C, D, E, F, G, H, I, object> processCall, IEnumerable<A> aList, IEnumerable<B> bList, IEnumerable<C> cList, IEnumerable<D> dList, IEnumerable<E> eList, IEnumerable<F> fList, IEnumerable<G> gList, IEnumerable<H> hList, IEnumerable<I> iList)
        {
            ApproveAllCombinations(processCall, "[{0},{1},{2},{3},{4},{5},{6},{7},{8}]", aList, bList, cList, dList, eList, fList, gList, hList, iList);
        }

        private static void ApproveAllCombinations<A, B, C, D, E, F, G, H, I>(Func<A, B, C, D, E, F, G, H, I, object> processCall, string format, IEnumerable<A> aList, IEnumerable<B> bList, IEnumerable<C> cList, IEnumerable<D> dList, IEnumerable<E> eList, IEnumerable<F> fList, IEnumerable<G> gList, IEnumerable<H> hList, IEnumerable<I> iList)

        {
            var sb = new StringBuilder();
            AllCombinations((a, b, c, d, e, f, g, h, i) =>
                            	{
                            		object result;
                            		try
                            		{
                            			result = processCall(a, b, c, d, e, f, g, h, i);
                            		}
                            		catch (Exception ex)
                            		{
                            			result = ex.Message;
                            		}
                            		var input = String.Format(format, a, b, c, d, e, f, g, h, i);
                            		sb.Append(String.Format("{0} => {1}\r\n", input, result));
                            	}, aList, bList, cList, dList, eList, fList, gList, hList, iList);

            ApprovalTests.Approvals.Approve(sb);
        }

        
        private static void AllCombinations<A, B, C, D, E, F, G, H, I>(Action<A, B, C, D, E, F, G, H, I> processCall, IEnumerable<A> aList, IEnumerable<B> bList, IEnumerable<C> cList, IEnumerable<D> dList, IEnumerable<E> eList, IEnumerable<F> fList, IEnumerable<G> gList, IEnumerable<H> hList, IEnumerable<I> iList)
        {
            foreach (var a in aList)
                foreach (var b in bList)
                    foreach (var c in cList)
                        foreach (var d in dList)
                            foreach (var e in eList)
                                foreach (var f in fList)
                                    foreach (var g in gList)
                                        foreach (var h in hList)
                                            foreach (var i in iList)
                                            {
                                                processCall(a, b, c, d, e, f, g, h, i);
                                            }
        }
    }
}