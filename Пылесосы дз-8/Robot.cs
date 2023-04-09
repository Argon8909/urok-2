using System;

namespace HW_8;

    public class Robot : VacuumCleaner
    {
        public Robot(string model, int room ) : base(model, room)
        {
            _model = model;
        }
        private readonly string _model = null;
        public override void StartCleaning()
        {
            Console.WriteLine($"Robot vacuum cleaner {_model}, start the cleaning process in room number {_room}");
        }
    }
