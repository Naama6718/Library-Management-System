namespace DesignPatterns2
{
    public interface IBook
    {

        bool Borrow();
        bool Return();
        void PrintDetailsOfBook(int num);
    }

}