using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    // Yang Akan Di tampilkan pada panel Tanya
    
    [HideInInspector] public string[] _questionText, _askText, _notificationText;

    private void Awake()
    {
        SetAnswerText();
        SetQuestionText();
        SetNotificationText();
    }

    public void SetQuestionText()
    {
        _questionText = new string[16];

        //Termin 1
        _questionText[0] = "Pentingnya personal hygiene: handler merupakan faktor penting dalam pengolahan makanan. Handler dapat menjadi sumber kontaminasi bagi makanan, ataupun menjadi vector kontaminan. Karenanya sangat penting untuk handler menjaga personal hygiene dan mematuhi Standar operasional untuk sanitasi";

        //Termin 2
        _questionText[1] = "Apakah anda sedang sakit flu ?";
        _questionText[2] = "Apakah anda sedang batuk atau pilek";
        _questionText[3] = "Apakah anda memiliki luka atau bisul terbuka di bagian lengan atau bagian tubuh lainnya ?";
        _questionText[4] = "Apakah anda sedang diare atau penyakit pencernaan lainnya ?";

        //Termin 3
        _questionText[5] = "Anda akan berangkat menuju tempat pengolahan pangan, apa yang anda lakukan ?";
        _questionText[6] = "Setelah mandi dengan bersih, hal apa yang lakukan selanjutnya ?";
        _questionText[7] = "Setelah mandi dengan bersih hal apa yang akan anda lakukan selanjutnya ?";

        //Termin 4
        _questionText[8] = "Sesampainya di tempat pengolahan pangan, hal apa yang harus anda lakukan ?"; // muncul 2 kali

        //Termin 5
        _questionText[9] = "Sebelum anda masuk kedalam ruang kerja, apakah yang anda harus lakukan ?";
        _questionText[10] = "Dalam mencuci tangan terdapat urutan yang benar, pilihlah tahapan berikut ini sesuai dengan tahapan yang benar !";
        _questionText[11] = "Maaf pilihan anda salah, silahkan memilih tahapan yang benar";

        //Termin 6
        _questionText[12] = "Sebelum anda memulai pekerjaan anda harus menggunakan pakaian yang sudah memenuhi standar hygine"; // part 1
        _questionText[13] = "silahkan anda pilih pakaian berikut : \npenutup kepala, celemek, masker dan sepatu";

        //Termin 7
        _questionText[14] = "Setelah perlengkapan anda siap, terdapat berbagai hal yang tidak boleh dilakukan Ketika sedang di ruang kerja";
        _questionText[15] = "Pililah 3 kegiatan yang anda tidak boleh lakukan di ruang kerja pada saat mengolah makanan !";
        _questionText[16] = "Maaf pilihan anda salah, silahkan memilih kegiatan yang lain";
    }

    public void SetNotificationText()
    {
        _notificationText[16] = "Maaf, Kondisi anda tidak memenuhi standar personal hygiene untuk menjadi penjamah makanan";
        _notificationText[17] = "Selamat !! anda dapat ke tahapan selanjutnya!";
        _notificationText[18] = "Selamat !! Kondisi anda telah memenuhi standar personal hygiene untuk menjadi penjamah makanan";
    }

    public void SetAnswerText()
    {
        _askText = new string[6];

        //Termin 2
        _askText[0] = "Ya";
        _askText[0] = "Tidak";

        //Termin 3
        _askText[0] = "Mandi dan keramans menggunakan sabun dan shampoo hingga bersih";
        _askText[0] = "Langsung berangkat ke tempat kerja";
        _askText[0] = "Berdandan, Menggunakan Make-Up secantik mungkin";
        _askText[0] = "Berdandan, Seperlunya dan menggunakan deodorant";

        //Termin 4
        _askText[0] = "Langsung masuk tempat pengolahan pangan"; //digunakan 2 kali
        _askText[0] = "Melepaskan perhiasan dan aksesoris lainya";
        _askText[0] = "memastikan tidak memakai kutek / cat kuku";
        _askText[0] = "Bersiap untuk berganti pakaian";

        //Termin 5
        _askText[0] = "Berganti pakaian kerja";
        _askText[0] = "Mencuci tangan dan kaki menggunakan sabun";

        _askText[0] = "Basahi tanganmu dengan air mengalir";
        _askText[0] = "Pakai sejumlah kecil sabun";
        _askText[0] = "Gosok kedua telapak tangan bersamaan";
        _askText[0] = "Gosok jemari, kuku dan telapak tangan mu selama 20 detik";
        _askText[0] = "Bilas menggunakan air bersih  yang mengalir";
        _askText[0] = "Keringkan dengan handuk atau tisu yang bersih";

        //Termin 7
        _askText[0] = "Mengupil";
        _askText[0] = "Menggaruk";
        _askText[0] = "Makan dan minum";
        _askText[0] = "Mengobrol";
    }

}
