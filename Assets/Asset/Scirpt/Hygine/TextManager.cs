using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    // Yang Akan Di tampilkan pada panel Tanya
    
    [HideInInspector] public string[] _questionText, _answerText, _notificationText;

    private void Awake()
    {
        SetAnswerText();
        SetQuestionText();
        SetNotificationText();
    }

    public void SetQuestionText()
    {
        _questionText = new string[19];

        //Termin 1
        _questionText[0] = "Pentingnya personal hygiene: handler merupakan faktor penting dalam pengolahan makanan.";
        _questionText[1] = "Handler dapat menjadi sumber kontaminasi bagi makanan, ataupun menjadi vector kontaminan.";
        _questionText[2] = "Karenanya sangat penting untuk handler menjaga personal hygiene dan mematuhi Standar operasional untuk sanitasi.";
        //Termin 2
        _questionText[3] = "Apakah anda sedang sakit flu ?";
        _questionText[4] = "Apakah anda sedang batuk atau pilek ?";
        _questionText[5] = "Apakah anda memiliki luka atau bisul terbuka di bagian lengan atau bagian tubuh lainnya ?";
        _questionText[6] = "Apakah anda sedang diare atau penyakit pencernaan lainnya ?";

        //Termin 3
        _questionText[7] = "Anda akan berangkat menuju tempat pengolahan pangan, apa yang anda lakukan ?";
        _questionText[8] = "Setelah mandi dengan bersih, hal apa yang lakukan selanjutnya ?"; // gak di pake
        _questionText[9] = "Setelah mandi dengan bersih hal apa yang akan anda lakukan selanjutnya ?";

        //Termin 4
        _questionText[10] = "Sesampainya di tempat pengolahan pangan, hal apa yang harus anda lakukan ?"; // muncul 2 kali

        //Termin 5
        _questionText[11] = "Sebelum anda masuk kedalam ruang kerja, apakah yang anda harus lakukan ?";
        _questionText[12] = "Dalam mencuci tangan terdapat urutan yang benar, pilihlah tahapan berikut ini sesuai dengan tahapan yang benar !";
        _questionText[13] = "Maaf pilihan anda salah, silahkan memilih tahapan yang benar";

        //Termin 6
        _questionText[14] = "Sebelum anda memulai pekerjaan anda harus menggunakan pakaian yang sudah memenuhi standar hygine";
        _questionText[15] = "silahkan anda pilih pakaian berikut : \npenutup kepala, celemek, masker dan sepatu";

        //Termin 7
        _questionText[16] = "Setelah perlengkapan anda siap, terdapat berbagai hal yang tidak boleh dilakukan Ketika sedang di ruang kerja";
        _questionText[17] = "Pililah 3 kegiatan yang anda tidak boleh lakukan di ruang kerja pada saat mengolah makanan !";
        _questionText[18] = "Maaf pilihan anda salah, silahkan memilih kegiatan yang lain";
    }

    public void SetNotificationText()
    {
        _notificationText = new string[3];

        _notificationText[0] = "Maaf, Kondisi anda tidak memenuhi standar personal hygiene untuk menjadi penjamah makanan";
        _notificationText[1] = "Selamat !! anda dapat ke tahapan selanjutnya!";
        _notificationText[2] = "Selamat !! Kondisi anda telah memenuhi standar personal hygiene untuk menjadi penjamah makanan";
    }

    public void SetAnswerText()
    {
        _answerText = new string[22];

        //Termin 2
        _answerText[0] = "Ya";
        _answerText[1] = "Tidak";

        //Termin 3
        _answerText[2] = "Mandi dan keramans menggunakan sabun dan shampoo hingga bersih";
        _answerText[3] = "Langsung berangkat ke tempat kerja";
        _answerText[4] = "Berdandan, Menggunakan Make-Up secantik mungkin";
        _answerText[5] = "Berdandan, Seperlunya dan menggunakan deodorant";

        //Termin 4
        _answerText[6] = "Langsung masuk tempat pengolahan pangan"; //digunakan 2 kali
        _answerText[7] = "Melepaskan perhiasan dan aksesoris lainya";
        _answerText[8] = "memastikan tidak memakai kutek / cat kuku";
        _answerText[9] = "Bersiap untuk berganti pakaian";

        //Termin 5
        _answerText[10] = "Berganti pakaian kerja";
        _answerText[11] = "Mencuci tangan dan kaki menggunakan sabun";

        _answerText[12] = "Basahi tanganmu dengan air mengalir";
        _answerText[13] = "Pakai sejumlah kecil sabun";
        _answerText[14] = "Gosok kedua telapak tangan bersamaan";
        _answerText[15] = "Gosok jemari, kuku dan telapak tangan mu selama 20 detik";
        _answerText[16] = "Bilas menggunakan air bersih  yang mengalir";
        _answerText[17] = "Keringkan dengan handuk atau tisu yang bersih";

        //Termin 7
        _answerText[18] = "Mengupil";
        _answerText[19] = "Menggaruk";
        _answerText[20] = "Makan dan minum";
        _answerText[21] = "Mengobrol";
    }

}
