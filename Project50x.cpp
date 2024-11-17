#include <iostream>       // Giriþ ve çýkýþ iþlemleri için gerekli olan kütüphaneyi dahil eder.
using namespace std;      // std isim alanýný kullanarak kodu basitleþtirir.

int k = 0;                // Global bir sayaç deðiþkeni tanýmlar ve baþlangýç deðeri olarak 0 atar.

int kattoplam(int A[], int i, int n) {   // `kattoplam` fonksiyonunu tanýmlar, A dizisi, i ve n parametrelerini alýr.
    if (n == 1) return A[i];             // Eðer dizi boyutu 1 ise, doðrudan A[i] elemanýný döndürür.
    else {                               // Aksi halde, dizi boyutu 1'den büyükse.
        int toplam = kattoplam(A, i + n / 2, n / 2) + kattoplam(A, i, n / 2);  // Diziyi ikiye bölüp her iki yarýyý rekürsif olarak toplar.
        cout << ++k << ". toplam: " << toplam << endl;  // Her toplama iþlemini sýrasýyla ekrana yazdýrýr.
        return toplam;                // Toplam deðeri döndürür.
    }
}

int main() {                // Programýn ana fonksiyonunu tanýmlar.
    int A[8] = {8, 7, 6, 5, 4, 3, 2, 1};  // 8 elemanlý bir dizi tanýmlar ve baþlangýç deðerleri atar.
    cout<<kattoplam(A, 0, 8);      // `kattoplam` fonksiyonunu çaðýrarak diziyi iþler.

    system("pause");         // Programýn bitiminde ekranda duraklatma yapar (Windows sistemlerinde geçerlidir).
    return 0;                // Ana fonksiyonun baþarýlý bir þekilde bittiðini belirtir.
}

