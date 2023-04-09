using System;

namespace HW_8;

    public class Washing : VacuumCleaner
    {
        public Washing(string model, int room ) : base(model, room)
        {
            _model = model;
            _room = room;
        }

        private  string _model = null;
        private  int _room = 0;

        public  new  void StartCleaning()
        {
            Console.WriteLine($"Washing vacuum cleaner {_model}, start the cleaning process in room number {_room}");
        }
    }
