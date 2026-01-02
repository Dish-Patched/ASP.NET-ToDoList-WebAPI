namespace ToDoList_WebAPI
{
    public class TodoList
    {
        public int ID { get; private set; } 
        public string Title { get; set; }
        public bool IsDone { get; private set; }

        // EFCore will use this for making the database table
        private TodoList() { }

        public TodoList(string t, int Id)
        {
            this.ID = Id;
            this.Title = t;
            this.IsDone = false;
        }

        public void Done()
        {
            this.IsDone = true;
        }

    }
}
