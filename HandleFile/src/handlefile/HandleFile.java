package handlefile;

import java.io.FileInputStream;
import java.io.IOException;

public class HandleFile {

	public static void main(String[] args) throws IOException{
		showContent2("C:\\Users\\init\\Desktop\\kucun1.txt");
//		showContent3("C:\\Users\\init\\Desktop\\kucun1.txt");
	}
	private static void showContent2(String path) throws IOException {
		// 打开流
		FileInputStream fis = new FileInputStream(path);

		// 通过流读取内容
		byte[] byt = new byte[10024];
		int len = fis.read(byt);
		for (int i = 0; i < byt.length; i++) {
			System.out.print((char) byt[i]);
		}

		// 使用完关闭流
		fis.close();
	}
	private static void showContent3(String path) throws IOException {
		// 打开流
		FileInputStream fis = new FileInputStream(path);

		// 通过流读取内容
		byte[] byt = new byte[1024];
		// 从什么地方开始存读到的数据
		int start = 5;
		
		// 希望最多读多少个(如果是流的末尾，流中没有足够数据)
		int maxLen =20;

		// 实际存放了多少个
		int len = fis.read(byt, start, maxLen);

		for (int i = start; i < start + maxLen; i++) {
			System.out.print((char) byt[i]);
		}

		// 使用完关闭流
		fis.close();
	}
}
