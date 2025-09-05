namespace exp.dados
{
    public class bensimagen : entidade
    {
        //public int id { get; set; }// int(11) NOT NULL,
        public int sites_id { get; set; } // int(11) NOT NULL,
        public string id_bem { get; set; } // int(11) NOT NULL,
        public string extencao { get; set; } // char(4) NOT NULL,
        public string path { get; set; } // varchar(150) NOT NULL,
    }
}