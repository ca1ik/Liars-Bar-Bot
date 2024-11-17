#include <iostream>       // Giri� ve ��k�� i�lemleri i�in gerekli olan k�t�phaneyi dahil eder.
using namespace std;      // std isim alan�n� kullanarak kodu basitle�tirir.

int k = 0;                // Global bir saya� de�i�keni tan�mlar ve ba�lang�� de�eri olarak 0 atar.

int kattoplam(int A[], int i, int n) {   // `kattoplam` fonksiyonunu tan�mlar, A dizisi, i ve n parametrelerini al�r.
    if (n == 1) return A[i];             // E�er dizi boyutu 1 ise, do�rudan A[i] eleman�n� d�nd�r�r.
    else {                               // Aksi halde, dizi boyutu 1'den b�y�kse.
        int toplam = kattoplam(A, i + n / 2, n / 2) + kattoplam(A, i, n / 2);  // Diziyi ikiye b�l�p her iki yar�y� rek�rsif olarak toplar.
        cout << ++k << ". toplam: " << toplam << endl;  // Her toplama i�lemini s�ras�yla ekrana yazd�r�r.
        return toplam;                // Toplam de�eri d�nd�r�r.
    }
}

int main() {                // Program�n ana fonksiyonunu tan�mlar.
    int A[8] = {8, 7, 6, 5, 4, 3, 2, 1};  // 8 elemanl� bir dizi tan�mlar ve ba�lang�� de�erleri atar.
    cout<<kattoplam(A, 0, 8);      // `kattoplam` fonksiyonunu �a��rarak diziyi i�ler.

    system("pause");         // Program�n bitiminde ekranda duraklatma yapar (Windows sistemlerinde ge�erlidir).
    return 0;                // Ana fonksiyonun ba�ar�l� bir �ekilde bitti�ini belirtir.
}

