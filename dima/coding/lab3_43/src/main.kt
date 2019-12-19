import java.io.File
import java.io.RandomAccessFile

class BITMAPFILEHEADER{
    var bfType:Short = 0
    var bfSize:Int = 0
    var bfReserved1:Short = 0
    var bfReserved2:Short = 0
    var bfOffBits:Int = 0
}

class BITMAPINFOHEADER{
    var biSize:Int = 0
    var biWidth:Int = 0
    var biHeight:Int = 0
    var biPlanes:Short = 0
    var biBitCount:Short = 0
    var biCompression:Int = 0
    var biSizeImage:Int = 0
    var biXPelsPerMeter:Int = 0
    var biYPelsPerMeter:Int = 0
    var biClrUsed:Int = 0
    var biClrImportant:Int = 0
}

/* println("ЗАГАЛОВОК ФАЙЛА")
    FileH.bfType = f.readShort()
    println("Формат файла " + f.readByte().toChar() + f.readByte().toChar())
    println("Размер файла " + Integer.reverseBytes(f.readInt()))
    println("Зарезервированные данные " + f.readShort())
    println("Зарезервированные данные " + f.readShort())
    println("Адрес с которого начинается изображение " + Integer.reverseBytes(f.readInt()))
    println("ЗАГАЛОВОК ИЗОБРАЖЕНИЯ")
    println("Размер загаловка " + Integer.reverseBytes(f.readInt()))
    val width = Integer.reverseBytes(f.readInt())
    println("Ширина изображения в пикселях " + width)
    println("Высота изображения в пикселях " + Integer.reverseBytes(f.readInt()))
    println("Зарезервированные данные " + f.readByte())
    f.skipBytes(1)
    println("Глубина цвета - количество битов в пикселях " + f.readByte())
    f.skipBytes(1)
    println("Метод сжатия " + Integer.reverseBytes(f.readInt()))
    println("Размер изображения(без заголовков) " + Integer.reverseBytes(f.readInt()))*/

object RLE{

    fun rle(inputFile: File, outputFile: File ){
        var enter = inputFile.readText()
        val raf = RandomAccessFile(outputFile, "rw")

        while(true){
            var j = 0
            while(j+1 <= enter.length-1 && enter[j+1] == enter[0]){
                j++
            }
            raf.writeShort(j+1)
            raf.writeShort(enter[0].toInt())
            if (j+1 > enter.length-1) break
            enter = enter.substring(j+1)
        }

        raf.close()
    }
}

class Cod_dec(){
    fun read_head(){
        val f = RandomAccessFile("bmp.bmp", "rw")
        f.seek(0)
        println("ЗАГАЛОВОК ФАЙЛА")
        println("Формат файла " + f.readByte().toChar() + f.readByte().toChar())
        println("Размер файла " + Integer.reverseBytes(f.readInt()))
        println("Зарезервированные данные " + f.readShort())
        println("Зарезервированные данные " + f.readShort())
        println("Адрес с которого начинается изображение " + Integer.reverseBytes(f.readInt()))
        println("ЗАГАЛОВОК ИЗОБРАЖЕНИЯ")
        println("Размер заголовка " + Integer.reverseBytes(f.readInt()))
        val width = Integer.reverseBytes(f.readInt())
        println("Ширина изображения в пикселях " + width)
        println("Высота изображения в пикселях " + Integer.reverseBytes(f.readInt()))
        println("Зарезервированные данные " + f.readByte())
        f.skipBytes(1)
        println("Глубина цвета - количество битов в пикселях " + f.readByte())
        f.skipBytes(1)
        println("Метод сжатия " + Integer.reverseBytes(f.readInt()))
        println("Размер изображения(без заголовков) " + Integer.reverseBytes(f.readInt()))}


    fun coding(file: File){
        val f = RandomAccessFile(file, "rw")
        val FileH = BITMAPFILEHEADER()
        val InfoH = BITMAPINFOHEADER()
        val listOfByte = mutableListOf<Byte>()
        while(f.filePointer.toInt() != 54){
            listOfByte.add(f.readByte())
        }
        f.seek(0)
        FileH.bfType = f.readShort()
        FileH.bfSize = Integer.reverseBytes(f.readInt())
        FileH.bfReserved1 = f.readShort()
        FileH.bfReserved2 = f.readShort()
        FileH.bfOffBits = Integer.reverseBytes(f.readInt())
        //-----------------------------
        InfoH.biSize = Integer.reverseBytes(f.readInt())
        InfoH.biWidth = Integer.reverseBytes(f.readInt())
        InfoH.biHeight = Integer.reverseBytes(f.readInt())
        InfoH.biPlanes = f.readShort()
        InfoH.biBitCount = f.readShort()
        InfoH.biCompression = Integer.reverseBytes(f.readInt())
        InfoH.biSizeImage = Integer.reverseBytes(f.readInt())
        InfoH.biXPelsPerMeter = Integer.reverseBytes(f.readInt())
        InfoH.biYPelsPerMeter = Integer.reverseBytes(f.readInt())
        InfoH.biClrUsed = Integer.reverseBytes(f.readInt())
        InfoH.biClrImportant = Integer.reverseBytes(f.readInt())

        val listOfBGR = mutableListOf<Triple<Int,Int,Int> >()
        f.seek(54)
        var v: Int = f.filePointer.toInt()
        while(v != FileH.bfSize){
            var j = 0
            while(j < InfoH.biWidth) {
                listOfBGR.add(Triple(f.readUnsignedByte(), f.readUnsignedByte(), f.readUnsignedByte()))
                j++
            }
            f.skipBytes(InfoH.biWidth % 4)
            v = f.filePointer.toInt()
        }
        f.close()

        val blueRazl = RandomAccessFile(File("blueRazl.bmp"), "rw" )
        val greenRazl = RandomAccessFile(File("greenRazl.bmp"), "rw" )
        val redRazl = RandomAccessFile(File("redRazl.bmp"), "rw" )

        blueRazl.write(listOfByte.toByteArray())
        greenRazl.write(listOfByte.toByteArray())
        redRazl.write(listOfByte.toByteArray())

        var k = 0
        for (it in listOfBGR) {

            blueRazl.writeByte(it.first); blueRazl.writeByte(0); blueRazl.writeByte(0)
            greenRazl.writeByte(0); greenRazl.writeByte(it.second); greenRazl.writeByte(0)
            redRazl.writeByte(0); redRazl.writeByte(0); redRazl.writeByte(it.third)
            k++
            if (k == InfoH.biWidth ){
                repeat(InfoH.biWidth % 4) {
                    blueRazl.writeByte(0)
                    greenRazl.writeByte(0)
                    redRazl.writeByte(0)
                }
                k=0
            }
        }

        blueRazl.close();greenRazl.close();redRazl.close();

        val blueBuff = File("blueBuff.txt")
        val greenBuff = File("greenBuff.txt")
        val redBuff = File("redBuff.txt")

        listOfBGR.forEach {
            blueBuff.appendText("${it.first.toShort().toChar()}")
            greenBuff.appendText("${it.second.toShort().toChar()}")
            redBuff.appendText("${it.third.toShort().toChar()}")
        }

        val blueRleFile = File("blueRLE.dat")
        val greenRleFile = File("greenRLE.dat")
        val redRleFile = File("redRLE.dat")
        RLE.rle(blueBuff,blueRleFile)
        RLE.rle(greenBuff,greenRleFile)
        RLE.rle(redBuff,redRleFile)

        val resultFile = RandomAccessFile(File("resultFile.dat"), "rw")
        resultFile.write(blueRleFile.readBytes())
        resultFile.writeShort(-100)
        resultFile.write(greenRleFile.readBytes())
        resultFile.writeShort(-100)
        resultFile.write(redRleFile.readBytes())
        resultFile.writeShort(-100)
        resultFile.writeShort(InfoH.biWidth)
        resultFile.writeShort(InfoH.biHeight)
        //delete all buff files
        blueRleFile.delete(); greenRleFile.delete(); redRleFile.delete()
        blueBuff.delete(); greenBuff.delete(); redBuff.delete()
    }

    fun decoding(resultFile: File) {

        val raf = RandomAccessFile(resultFile, "rw")

        val blueBuff = File("blueBuff.txt")
        val greenBuff = File("greenBuff.txt")
        val redBuff = File("redBuff.txt")

        while(raf.filePointer != raf.length()){
            val buff1 = raf.readShort()
            if (buff1 == (-100).toShort()){
                break
            }
            val buff2 = raf.readShort()

            repeat(buff1.toInt()){
                blueBuff.appendText("${buff2.toChar()}")
            }
        }

        while(raf.filePointer != raf.length()){
            val buff1 = raf.readShort()
            if (buff1 == (-100).toShort()){
                break
            }
            val buff2 = raf.readShort()
            repeat(buff1.toInt()){
                greenBuff.appendText("${buff2.toChar()}")
            }
        }
        while(raf.filePointer != raf.length()){
            val buff1 = raf.readShort()
            if (buff1 == (-100).toShort()){
                break
            }
            val buff2 = raf.readShort()
            repeat(buff1.toInt()){
                redBuff.appendText("${buff2.toChar()}")
            }
        }

        val width = raf.readShort()
        val height = raf.readShort()


        val decodedPict = File("decodedPict.bmp")
        val decodedFile = RandomAccessFile(decodedPict,"rw")
        decodedFile.apply {
            writeByte('B'.toInt())
            writeByte('M'.toInt())
            writeInt( Integer.reverseBytes(width * height * 3 + 54) )  //size of file
            writeShort(0)       //needed
            writeShort(0)        // fields
            writeInt( Integer.reverseBytes(54) )
            writeInt( Integer.reverseBytes(40) )
            writeInt( Integer.reverseBytes( width.toInt() ) )
            writeInt( Integer.reverseBytes( height.toInt() ) )
            writeByte(1); writeByte(0)
            writeByte(24); writeByte(0)
            writeInt(0)
            writeInt(Integer.reverseBytes( width * height * 3) )
            writeInt(Integer.reverseBytes(2795) )
            writeInt(Integer.reverseBytes(2795) )
            writeInt(0)
            writeInt(0)
        }

        val blueText = blueBuff.readText()
        val greenText = greenBuff.readText()
        val redText = redBuff.readText()

        var k = 0
        for(i in 0 until width * height){
            val b = blueText[i]
            val g = greenText[i]
            val r = redText[i]

            decodedFile.writeByte(b.toInt())
            decodedFile.writeByte(g.toInt())
            decodedFile.writeByte(r.toInt())
            k++
            if (k == width.toInt()){
                repeat(width % 4) {
                    decodedFile.writeByte(0)
                }
                k=0
            }

        }

        blueBuff.delete(); greenBuff.delete(); redBuff.delete()
        decodedFile.close()
        raf.close()
    }

    fun addBuffer(arr: ByteArray): MutableList<Boolean> {
        var tex = mutableListOf<Boolean>()
        arr.forEach {
            var str = Integer.toBinaryString(it.toInt())
            if (str.length>8){
                str = str.substring(str.length-8)
            }
            var s =str.length

            if (s!=8){
                var ost =8- (s%8)
                var  i = 1
                for (i  in 1..ost) str = "0" + str
            }
            str.forEach {
                if (it == '0') tex.add(false)
                else tex.add(true)
            }}
        return tex
    }

    fun dop (file: File,enterFile: File,exitFile: File){

        var otherbit = mutableListOf<Byte>()
        val f = RandomAccessFile(file, "rw")
        val list = mutableListOf<Byte>()
        while(f.filePointer.toInt() != 54){
            list.add(f.readByte())
        }
        f.seek(2)
        val size = Integer.reverseBytes(f.readInt())
        val TextPict = File("Textbmp.bmp")
        val TextFile = RandomAccessFile(TextPict,"rw")
        TextFile.write(list.toByteArray())
        if (size-54 < enterFile.readText().length*4){
            println("Нехватка памяти")
            return
        }
        TextFile.seek(54)
        var x = enterFile.readText().toByteArray()
        val sizeImage = x.size
        var tex = addBuffer(x)

        f.seek(54)
        var count = 0
        println("Вставка текста в изображение ...")
        for (i in 0 until tex.size/8){
            var b = f.readUnsignedByte()
            var g = f.readUnsignedByte()
            var r  =f.readUnsignedByte()
            var b2 = f.readUnsignedByte()
            for (j in 1..2){
                if (tex[count]){
                    b = b or ((1) shl (2 - j))
                    count+=1
                }
                else {
                    b = b and ((1) shl (2 - j)).inv()
                    count+=1
                }
            }
            for (j in 1..2){
                if (tex[count]){
                    g = g or ((1) shl (2 - j))
                    count+=1
                }
                else {
                    g = g and ((1) shl (2 - j)).inv()
                    count+=1
                }
            }
            for (j in 1..2){
                if (tex[count]){
                    r = r or ((1) shl (2 - j))
                    count+=1
                }
                else {
                    r = r and ((1) shl (2 - j)).inv()
                    count+=1
                }
            }
            for (j in 1..2){
                if (tex[count]){
                    b2 = b2 or ((1) shl (2 - j))
                    count+=1
                }
                else {
                    b2 = b2 and ((1) shl (2 - j)).inv()
                    count+=1
                }
            }
            TextFile.writeByte( b )
            TextFile.writeByte( g )
            TextFile.writeByte( r )
            TextFile.writeByte( b2 )
        }
        while(f.filePointer.toInt() != size){
            otherbit.add(f.readByte())
        }
        TextFile.write(otherbit.toByteArray())
        println("Текст вставлен")
        var restext = " "
        var d = mutableListOf<Byte>()
        TextFile.seek(54)
        for (i in 1..sizeImage*4){
            var b = TextFile.readUnsignedByte().toUByte()
            d.add(b.toByte())
        }

        var a = d.toByteArray()
        var let = addBuffer(a)
        count = 8
        var buf = 0
        for (i in 6 .. let.size step 8){
            if (let[i] == true){
                buf = buf or (1 shl (count-1))
                count-=1
            }
            if (let[i]==false){
                buf = buf and ((1) shl (count-1)).inv()
                count-=1
            }
            if (count == 0){
                count = 8
                restext+=buf.toChar()
                buf= 0
                continue
            }
            if (let[i+1] == true){
                buf = buf or (1 shl (count-1))
                count-=1
            }
            if (let[i+1]==false){
                buf = buf and ((1) shl (count-1)).inv()
                count-=1
            }
            if (count == 0){
                count = 8
                restext+=buf.toChar()
                buf= 0
                continue
            }
        }
        exitFile.writeText(restext)
    }

    fun knife(file: File){
        val f = RandomAccessFile(file, "rw")
        val list = mutableListOf<Byte>()
        while(f.filePointer.toInt() != 54){
            list.add(f.readByte())
        }
        for (i in 0..7) {
            f.seek(54)
            var file2 = RandomAccessFile(File("knife\\${i+1}.bmp"), "rw")
            file2.write(list.toByteArray())
            println(i)
            while (f.filePointer != f.length()) {
                var b = f.readUnsignedByte()
                b = b shr i+1
                file2.writeByte(b)
            }
        }
    }
}

fun main()
{
    val code_dec = Cod_dec()
    //code_dec.read_head()
    //code_dec.knife(File("bmp.bmp"))
    //code_dec.coding(File("bmp.bmp"))

    code_dec.decoding(File("resultFile.dat"))
    /*code_dec.dop(File("bmp.bmp"),
        File("enter.txt"), File("exit.txt"))*/
}