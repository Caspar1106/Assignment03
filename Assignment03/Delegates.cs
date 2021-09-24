using System;
public static class Delegates{
    
    public static Func<string, string> reverse = org => rev(org);
    static string rev(string original){
        string reverse = string.Empty;

        for(int i = 0; i < original.Length; i++){
            reverse += original[original.Length - 1 - i];
        }
        return reverse;
    }
    public static Func<double, double, double> product = (a,b) => a*b;

    public static Func<string, int, bool> numericallyEqual = (str, i) => numericallyEquivalent(str, i);

    static bool numericallyEquivalent(string str, int i){
        if (Int32.TryParse(str, out int r)){
            return r == i;
        }
        
        return false;
    }

}