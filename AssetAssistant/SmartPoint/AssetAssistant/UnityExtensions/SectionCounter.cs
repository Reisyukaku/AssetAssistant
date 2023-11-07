using System.Collections.Generic;
using UnityEngine;

namespace SmartPoint.AssetAssistant.UnityExtensions
{
    public class SectionCounter
    {
        private static Dictionary<object, SectionCounter> _sections;

        public float startTime { get; set; }
        public float lastTime { get; set; }
        public int count { get; set; }
        public float minTime { get; set; }
        public float maxTime { get; set; }
        public float averageTime { get; set; }
        private float nestedCount { get; set; }

        [AssetAssistantInitializeMethod(0)]
        private static void Initialize()
        {
            throw new NotImplementedException();
        }

        public static void Start(object key)
        {
            SectionCounter secCnt = null;
            if (!_sections.TryGetValue(key, out secCnt))
            {
                secCnt = new SectionCounter();
                secCnt.startTime = Time.realtimeSinceStartup;
                _sections.Add(key, secCnt);
            }
            else
            {
                secCnt.startTime = Time.realtimeSinceStartup;
                _sections[key] = secCnt;
            }
        }

        public static SectionCounter End(object key) {
            SectionCounter secCnt = null;
            if (!_sections.TryGetValue(key, out secCnt))
            {
                secCnt = new SectionCounter();
                secCnt.lastTime = Time.realtimeSinceStartup - secCnt.startTime;
                _sections.Add(key, secCnt);
            }
            else
            {
                secCnt.lastTime = Time.realtimeSinceStartup - secCnt.startTime;
                _sections[key] = secCnt;
            }

            return secCnt;
        }

        public SectionCounter()
        {
            _sections = new Dictionary<object, SectionCounter>();
        }
    }
}
