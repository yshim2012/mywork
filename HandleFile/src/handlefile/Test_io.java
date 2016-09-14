package handlefile;

import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;

public class Test_io {

	public static void main(String[] args) throws IOException {
		String path = "C:\\Users\\init\\Desktop\\test.txt";
		writeTxtFile(path);
		writeTxtFile2(path);
	}
	private static void writeTxtFile(String path) throws IOException{
		FileOutputStream fos =new FileOutputStream(path);
		fos.write('j');
		fos.write('\r');
		fos.write('k');
		fos.write('s');
		fos.close();
	}
	private static void writeTxtFile2(String path) throws IOException {
		// 1：打开文件输出流，流的目的地是指定的文件
		FileOutputStream fos = new FileOutputStream(path,true);

		// 2：通过流向文件写数据
		byte[] byt = "java".getBytes();
		fos.write(byt);
		// 3:用完流后关闭流
		fos.close();
	}


}
