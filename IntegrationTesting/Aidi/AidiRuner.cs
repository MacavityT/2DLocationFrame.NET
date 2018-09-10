using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using Aqrose.Aidi;

namespace aidi_client
{
    class AidiRuner
    {
        private AidiFactoryRunner aidi_;
        private string check_code_ = "";
        private bool is_ready = false;
        // work_path must be as below:
        // Location_0
        // Detect_1
        public AidiRuner(string code = "")
        {
            check_code_ = code;
        }

        public bool get_is_ready(){
            return is_ready;
        }

        public bool Init(string work_path, int gpu_number, IntVector batch_size)
        {
            if (!is_ready) {
                // get module_type list
                StringVector module_type = get_all_module_from_work_path(work_path);
                foreach (string type in module_type)
                {
                    Console.WriteLine("module type : " + type);
                }
                // check batch_size
                if (module_type.Count != batch_size.Count)
                {
                    Console.WriteLine("module type must = batch_size numnber");
                    // return false;
                }
                StringVector module_model_list = new StringVector();
                for (int i = 0; i < module_type.Count; i++)
                {
                    string current_module_model_path = work_path + "/" + module_type[i] + "_" + i.ToString() + "/model/";
                    string current_module_model_aqbin_path = work_path + "/" + module_type[i] + "_" + i.ToString() + "/model/model.aqbin";
                    string current_module_model_json_path = work_path + "/" + module_type[i] + "_" + i.ToString() + "/model/param.json";
                    // check model path 
                    if (!File.Exists(current_module_model_aqbin_path))
                    {
                        throw new FileNotFoundException("模型文件model.aqbin不存在，当前路径：" + current_module_model_path);
                    }
                    if (!File.Exists(current_module_model_json_path))
                    {
                        throw new FileNotFoundException("模型配置文件param.json不存在，当前路径：" + current_module_model_path);
                    }
                    if (!Directory.Exists(current_module_model_path))
                    {
                        throw new FileNotFoundException("模型路径不存在，当前路径：" + current_module_model_path);
                    }
                    module_model_list.Add(current_module_model_path);
                }
                for (int i = 0; i < module_model_list.Count; i++)
                {
                    Console.WriteLine(module_model_list[i]);
                }

                // init 
                aidi_ = new AidiFactoryRunner(check_code_);
                FactoryClientParamWrapper param = new FactoryClientParamWrapper();
                param.device_number = gpu_number;
                param.save_model_path_list = module_model_list;
                param.operator_type_list = module_type;
                param.use_runtime = false;
                aidi_.set_param(param);
                aidi_.set_batch_size(batch_size);
                aidi_.start();
                is_ready = true;
            }
            return is_ready;
            

        }
        public void set_detect_images(List<Bitmap> bitmap_list)
        {
            // transform images
            BatchAidiImage aidi_images = new BatchAidiImage();
            //AidiImage image_t = new AidiImage();
            //image_t.read_image("D:/aidi_benchmark/location_sample_mobilephone/Location_0/source/1.bmp");
            for (int i = 0; i < bitmap_list.Count; i++)
            {

                Bitmap current_bitmap = bitmap_list[i];



                AidiImage image = new AidiImage();
                string bit_number = current_bitmap.PixelFormat.ToString();
                int channel_number = 1;
                if (bit_number.Contains("24")) // 24位即为3通道，8位为1通道
                    channel_number = 3;
                else
                    channel_number = 1;
                int stride;
                DateTime dt1 = System.DateTime.Now;
                byte[] transform_image = GetBGRValues(bitmap_list[i], out stride);
                image.char_ptr_to_mat(transform_image, current_bitmap.Height, current_bitmap.Width, channel_number);
                aidi_images.add_image(image);
                DateTime dt2 = System.DateTime.Now;
                TimeSpan ts = dt2.Subtract(dt1);
                Console.WriteLine("wrap image time time {0}", ts.TotalMilliseconds);
                Console.WriteLine(aidi_images.get_images_size());
            }
            aidi_.set_test_batch_image(aidi_images);
        }

        public List<string> get_detect_result()
        {
            List<string> result_list = new List<string>();
            StringVector results = aidi_.get_detect_result();
            //image_t.draw_result(results[0]);
            //image_t.show_image(0);
            for (int i = 0; i < results.Count; i++)
            {
                result_list.Add(results[i]);
            }
            return result_list;
        }

        public List<string> Run(List<Bitmap> bitmap_list)
        {
            if (!is_ready)
            {
                throw new Exception("模型未初始化");
            }
            List<string> result_list = new List<string>();
            // transform images
            BatchAidiImage aidi_images = new BatchAidiImage();
            //AidiImage image_t = new AidiImage();
            //image_t.read_image("D:/aidi_benchmark/location_sample_mobilephone/Location_0/source/1.bmp");
            for (int i = 0; i < bitmap_list.Count; i++)
            {
                Bitmap current_bitmap = bitmap_list[i];
                AidiImage image = new AidiImage();
                string bit_number = current_bitmap.PixelFormat.ToString();
                int channel_number = 1;
                if (bit_number.Contains("24")) //24位即为3通道，8位为1通道
                    channel_number = 3;
                else
                    channel_number = 1;
                int stride;
                DateTime dt1 = System.DateTime.Now;
                byte[] transform_image = GetBGRValues(bitmap_list[i], out stride);
                image.char_ptr_to_mat(transform_image, current_bitmap.Height, current_bitmap.Width, channel_number);
                aidi_images.add_image(image);
                DateTime dt2 = System.DateTime.Now;
                TimeSpan ts = dt2.Subtract(dt1);
                Console.WriteLine("wrap image time time {0}", ts.TotalMilliseconds);
                Console.WriteLine(aidi_images.get_images_size());
            }
            aidi_.set_test_batch_image(aidi_images);
            StringVector results = aidi_.get_detect_result();
            //image_t.draw_result(results[0]);
            //image_t.show_image(0);
            for (int i = 0; i < results.Count; i++)
            {
                result_list.Add(results[i]);
            }
            //string result = aidi_.start_test(image_t);
            //result_list.Add(result);

            return result_list;
        }


        private StringVector get_all_module_from_work_path(string work_path)
        {
            DirectoryInfo root = new DirectoryInfo(work_path);
            DirectoryInfo[] dics = root.GetDirectories();
            StringVector module_type = new StringVector();
            if (dics.Length == 0)
            {
                throw new DirectoryNotFoundException("模型文件夹不存在，当前路径：" + work_path );
            }

            for (int i = 0; i < dics.Length; i++)
            {
                module_type.Add("");
            }
            foreach (DirectoryInfo child_directory in dics)
            {
                string name = child_directory.Name;

                string[] info_name = name.Split('_');
                if (info_name.Length < 2)
                {
                    throw new FileNotFoundException("模型名称非法，应该类似{module_name}_{number}(Detect_0)，当前路径：" + work_path + "， 当前类型" + info_name);
                }
                else
                {
                    if (info_name[0] != "Location" && info_name[0] != "Detect" && info_name[0] != "Classify" && info_name[0] != "FeatureLocation")
                    {
                        throw new FileNotFoundException("模型名称非法，应为(Location/Detect/Classify/FeatureLocation)中的一种，当前路径：" + work_path + "， 当前类型" + info_name[0]);
                    }
               
                    if (int.Parse(info_name[1]) >= dics.Length)
                    {
                        throw new FileNotFoundException("可能缺少名称形如***_0的文件夹，当前路径：" + work_path );
                    }
                    module_type[int.Parse(info_name[1])] = info_name[0];
                }

            }
            return module_type;
        }

        private static byte[] GetBGRValues(Bitmap bmp, out int stride)
        {
            var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            var bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);
            stride = bmpData.Stride;
            //int channel = bmpData.Stride / bmp.Width; 
            var rowBytes = bmpData.Width * Image.GetPixelFormatSize(bmp.PixelFormat) / 8;
            var imgBytes = bmp.Height * rowBytes;
            byte[] rgbValues = new byte[imgBytes];
            IntPtr ptr = bmpData.Scan0;
            for (var i = 0; i < bmp.Height; i++)
            {
                Marshal.Copy(ptr, rgbValues, i * rowBytes, rowBytes);   // 对齐
                ptr += bmpData.Stride; // next row
            }
            bmp.UnlockBits(bmpData);

            return rgbValues;
        }

        public void release()
        {
            if (get_is_ready())
            {
                aidi_.release();
                is_ready = false;
            }
            
            
        }


    }
}
