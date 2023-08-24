'use client'

<<<<<<< HEAD
import { useState } from "react";
import {useRouter} from 'next/navigation'
import { useAddBlogMutation } from "@/store/features/create-blog/create-blog-api";
=======
import { useAddBlogMutation } from "@/store/features/create-blog/create-blog-api";
import { useState } from "react";
>>>>>>> 71ad5a6 (feat(aait.web.g3):Add create blog page)
import AddBlog from "@/components/blog/AddBlog";

const CreateBlogPage: React.FC = () => {
    const [addBlog, {isError, isLoading}] = useAddBlogMutation()
    const [title, setTitle] = useState("");
    const [image, setImage] = useState<File | null>(null);
    const [content, setContent] = useState("");
    const [imageText, setImageText] = useState('Please upload image');
    const [selectedTags, setSelectedTags] = useState<string[]>([]);
<<<<<<< HEAD
    const router = useRouter()
=======
>>>>>>> 71ad5a6 (feat(aait.web.g3):Add create blog page)

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
<<<<<<< HEAD
            formData.append("image", image as Blob);
          }
  
          try {
            
            const response = await addBlog(formData);
            if (response) {
                router.push('/blogs')
            }else{
              setImage(null)
              setImageText('Please upload image')
              setContent('')
              setTitle('')
              setSelectedTags([])
              
=======
            formData.append("image", image);
          }
  
          try {
            const response = await addBlog(formData);
            if (response) {
                console.log(response)
>>>>>>> 71ad5a6 (feat(aait.web.g3):Add create blog page)
            }

          } catch (error) {
            
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