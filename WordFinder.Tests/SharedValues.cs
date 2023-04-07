namespace WordFinder.UnitTests
{
    public static class SharedValues
    {
        //Matrix
        public static IEnumerable<string> Matrix_ValidExample = new string[]
        {
            "abcdc",
            "fgwio",
            "chill",
            "pqnsd",
            "uvdxy"
        };
        public static IEnumerable<string> Matrix_With1WordHorizontallyFromRigthToLeft = new string[]
        {
            "abcdc",
            "fgwio",
            "llihc", // Word chill is from right to left,cold word will not be present either.
            "pqnsd",
            "uvdxy"
        };
        public static IEnumerable<string> Matrix_With1WordCrossOver = new string[]
        {
            "cbcdc",// Word chill is cross over the matrix
            "fhoio",
            "mhill",
            "pqnld",
            "uvdxl"
        };
        public static IEnumerable<string> Matrix_With1WordVerticallyFromBottomToTop = new string[]
        {
             "abcdd",
             "fgwil",
             "chilo",
             "pqnsc",// Cold is FromBottomToTop, chill word will not be present either.
             "uvdxy"
        };
        public static IEnumerable<string> Matrix_WithRepeteadRow = new string[]
        {
            "abcdc",
            "fgwio",
            "chill",
            "pqnsd",
            "uvdxy",
            "uvdxy"

        };
        public static IEnumerable<string> Matrix_WithRepeteadColumn = new string[]
        {
            "abcdcc",
            "fgwioo",
            "chilll",
            "pqnsdd",
            "uvdxyy"
        };
        public static IEnumerable<string> Matrix_ValidComplexExample= new string[]
        {
            "aabbcd/ci fym_qurocks",
            "abfgwi/oi fym_qurocks",
            "abchil/li fym_qurocks",
            "abpqns/di fym_qurocks",
            "abuvdx/yi fym_qurocks",
            "ababcd/ci fom_qurocks",
            "abfgwi/oi fom_qurocks",
            "abchil/li fom_qurocks",
            "abpqns/di fom_qurocks",
            "abuvdx/yi fom_qurocks",
            "oaabbc/dc ife_qurocks",
            "oabfgw/io ife3mirruls",
            "oabchi/ll ife3mirruls",
            "oabpqn/sd ife3mirruls",
            "oabuvd/xy ife3mirruls",
            "oababc/dc ife3mirruls",
            "oabfgw/io ife3mirruls",
            "oabchi/ll if3emirruls",
            "oabpqn/sd if3emirruls",
            "oabuvd/xy if3emirruls"
        };

        //Stream
        public static IEnumerable<string> Stream_ValidExample = new string[]
        {
            "cold",
            "wind",
            "snow",
            "chill"
        };
        public static IEnumerable<string> Stream_WithRepeteadWord = new string[]
        {
            "cold",
            "cold",
            "wind",
            "snow",
            "chill"
        };
        public static IEnumerable<string> Stream_ValidComplexExample = new string[]
        {
            "A",
            "e",
            "i",
            "o",
            "u",
            "l",
            "h",
            "c",
            "p",
            "m",
            "f",
            "q",
            "u",
            "r",
            "r",
            "r",
            "s"

        };
    }
}
