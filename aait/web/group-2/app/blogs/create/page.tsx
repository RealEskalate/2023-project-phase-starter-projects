'use client'

import { useState } from "react";
import {useRouter} from 'next/navigation'
import AddBlog from "@/components/blog/AddBlog";
import Cookies from "js-cookie";


const CreateBlogPage: React.FC = () => {
    const [title, setTitle] = useState("");
    const [image, setImage] = useState<File | null>(null);
    const [content, setContent] = useState("");
    const [imageText, setImageText] = useState('Please upload image');
    const [selectedTags, setSelectedTags] = useState<string[]>([]);
    const router = useRouter()

    const handleTagClick = (tag: string) => {
      if (selectedTags.includes(tag)) {
        setSelectedTags(selectedTags.filter((t) => t !== tag));
      } else {
        setSelectedTags([...selectedTags, tag]);
      }
    };

    const handleTitleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
          setTitle(event.target.value);
      };

    const handleImageChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        if (event.target.files && event.target.files.length > 0) {
            const file = event.target.files[0]
            if (file) {
                setImageText(file.name);
            } else {
                setImageText('Please upload image');
            }
        setImage(event.target.files[0]);
        }
    };

      const handleCancel = (e: React.FormEvent) => {
        e.preventDefault()
        setImage(null)
        setImageText('Please upload image')
        setContent('')
        setTitle('')
        setSelectedTags([])

      }

      const handleDeleteImage = () => {
          setImageText('Please upload image');
          setImage(null);
      };
      const handleContentChange = (newContent:any) => {
          setContent(newContent);
      };

      const handleSubmit = async (event: React.FormEvent) => {
          event.preventDefault();
          const formData = new FormData();
          formData.append("title", title);
          formData.append("description", content);
          selectedTags.forEach(tag => formData.append("tags", tag));
          if (image) {
            formData.append("image", image as Blob);
          }
          console.log(title, content,selectedTags);
          if (Cookies.get("user")){
            const user = JSON.parse(Cookies.get("user") || "");
            const token = user?.token;
            // make request here
            try {

              const response = await fetch('https://a2sv-backend.onrender.com/api/blogs', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    Authorization: `Bearer ${token}`,
                },
                body: formData,
              });

              if (response.ok) {
                const responseData = await response.json();
                console.log('Blog created:', responseData);
              } else {
                console.error('Error creating blog:', response);
              }

            }catch (error) {
              console.error('Error creating blog:', error);
            }
          }
          
          else{
            router.push("/signin")
          }
         
      };

    return (
     <AddBlog
      title={title}
      content={content}  
      image={image} 
      imageText={imageText} 
      selectedTags={selectedTags} 
      handleCancel={handleCancel}
      handleContentChange={handleContentChange}
      handleDeleteImage={handleDeleteImage}
      handleImageChange={handleImageChange}
      handleSubmit={handleSubmit}
      handleTagClick={handleTagClick}
      handleTitleChange={handleTitleChange}
      />
    );
};

export default CreateBlogPage;