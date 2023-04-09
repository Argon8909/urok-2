using System;
namespace HW_8;

    public class VacuumCleaner

    {
        public VacuumCleaner(string model, int room = 0)
        {
            _model = model;
            StartCleaning(room);
        }

        private readonly string _model;
        public virtual string Model => _model;

        public virtual void StartCleaning()
        {
            Console.WriteLine($"Vacuum cleaner {_model}, start the cleaning process in room number {_room}");
        }

        internal int _room;

        public virtual void StartCleaning(int roomNnumber)
        {
            if (roomNnumber < 0) throw new ArgumentOutOfRangeException(nameof(roomNnumber));
            _room = roomNnumber;
        }
    }
