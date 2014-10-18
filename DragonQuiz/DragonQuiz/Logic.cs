using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;

class Integration
{
    public class DQuestion
    {
        public int ID{ get; set; }
        public string Content{ get; set; }
        public string Answer{ get; set; }
        public string Comment{ get; set; }
        public string Tags{ get; set; }
    };

    public class Request
    {
        public int Number;
        public string Tags;
        public void setRequest(int n, string tags)
        {
            Number = n;
            Tags = tags;
        }
    };


    public static List<DQuestion> getPackage(Request request)
    {

        List<DQuestion> l = new List<DQuestion>();

        DQuestion q = new DQuestion();
        q.Content = "1968 год выдался богатым на разного рода революционную деятельность. Тут и 'красный май' во Франции, приведший к отставке де Голля, и закон М.Л. Кинга о запрете расовой дискриминации при продаже недвижимости, и 'Пражская весна'. Этот список будет явно неполным без упоминания еще двух событий, произошедших сразу в двух странах 22 и 25 ноября 1968 года, идейными вдохновителями и авторами которых были официально 2 человека, а реально — один. Назовите его.";
        q.Answer = "Джон Леннон";
        q.Comment = "автор Revolution N1 и N9, вышедших в указанные даты на White Album в Великобритании и США в формальном соавторстве с П. Маккартни.";
        q.Tags = "#чгк";
        l.Add(q);

        DQuestion q1 = new DQuestion();
        q1.Content = "Приложению требуется открыть и прочитать в память файл, хранимый на диске. Сколько блоков потребуется считать с диска для выполнения этой операции, если размер файла 2347722 байта, а диск разбит на блоки по 4096 байт.";
        q1.Answer = "574";
        q1.Comment = "источник: Stepic.org";
        q1.Tags = "#csc";
        l.Add(q1);

        DQuestion q2 = new DQuestion();
        q2.Content = "В сегментной модели памяти, каждый сегмент выровнен по границе X байт, то есть сегменты 0,1,2,... начинаются по адресам 0, X, 2X, ... Требуется найти X, если известно, что перечисленные ниже смещения от начала некоторых сегментов указывают на один и тот же адрес в памяти. 17, 9, 1";
        q2.Answer = "2";
        q2.Comment = "источник: Stepic.org";
        q2.Tags = "#csc";
        l.Add(q2);

        return l;
    }


}