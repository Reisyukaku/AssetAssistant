using System.Collections.Generic;
using UnityEngine;

namespace SmartPoint.AssetAssistant.UnityExtensions
{
    public class SectionCounter
    {
        private static Dictionary<object, SectionCounter> _sections;

        public float startTime
        {
            get; private set;
        }

        public float lastTime
        {
            get; private set;
        }

        public int count
        {
            get; private set;
        }

        public float minTime
        {
            get; private set;
        }

        public float maxTime
        {
            get; private set;
        }

        public float averageTime
        {
            get; private set;
        }

        private float nestedCount
        {
            get; set;
        }

        [AssetAssistantInitializeMethod(0)]
        private static void Initialize()
        {
            //
        }

        public static void Start(object key)
        {
            SectionCounter secCnt = null;
            var sec = _sections.TryGetValue(key, out secCnt);
            secCnt.startTime = Time.realtimeSinceStartup;
            _sections.Add(key, secCnt);
        }

        public static SectionCounter End(object key) {
            SectionCounter secCnt = null;
            var sec = _sections.TryGetValue(key, out secCnt);
            secCnt.lastTime = Time.realtimeSinceStartup - secCnt.startTime;
            //_sections.Add(key, secCnt);
            return secCnt;
        }

        public SectionCounter()
        {
        }

        static SectionCounter()
        {
        }
    }
}
