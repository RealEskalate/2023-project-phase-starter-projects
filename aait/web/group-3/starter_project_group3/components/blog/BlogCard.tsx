import React from 'react';
import { Blog, Author } from '@/types/blog/blog';
import parse from 'html-react-parser';


interface BlogProps extends Blog {
  author: Author | null;
}

const formatDate = (dateString: string): string => {
  const options = { year: 'numeric', month: 'long', day: 'numeric' };
  const date = new Date(dateString);
  return date.toDateString(); 
};

const MAX_DESCRIPTION_LENGTH = 150;

const BlogCard: React.FC<BlogProps> = ({
  author,
  image,
  title,
  description,
  tags,
  createdAt,
}) => {

  const truncatedDescription =
    description.length > MAX_DESCRIPTION_LENGTH
      ? `${description.substring(0, MAX_DESCRIPTION_LENGTH)}...`
      : description;

  return (
    <div>

      <div className="bg-white pl-8 rounded-md py-4  md:px-48">
        <hr className='my-6'/>
        <div className="flex  items-center mb-2">
          {author && (
            <img
              src={author.image }
              alt={`${author.name}'s Avatar`}
              className="w-16 h-16 rounded-full"
            />
          )}

          {!author && (
            <img
              src={'../assets/profile.png' }
              alt={`Avatar`}
              className="w-16 h-16 rounded-full"
            />
          )}
          <div className="ml-2">
            { 
              <div className="flex items-center">
                <p className="text-gray-600 font-semibold ">{author ? author.name : 'Unknown'}</p>
                <span className="text-xs text-gray-400 ml-2">. {formatDate(createdAt)}</span>
              </div>
            }
            {author && <p className="uppercase  text-gray-400 mt-1">Software Engineer</p>}
          </div>
        </div>
        <div className='flex justify-between flex-col gap-16 xl:flex-row'>
          <div>
            <h2 className="text-2xl font-bold mt-2">{title}</h2>
            <p className="text-gray-700 pr-20 text-wrap">{parse(truncatedDescription)}</p>
            {description.length > MAX_DESCRIPTION_LENGTH && (
                <a className="text-primary">Read more</a>
            )}
            <div className="flex flex-wrap mt-4">
              {tags.map((tag, index) => (
                <span
                  key={index}
                  className="bg-gray-100  self-center text-gray-600 px-2 py-1 rounded-full mr-2 mb-2"
                >
                  {tag}
                </span>
              ))}
            </div>
          </div>
          <div>
          <div className='h-48 w-72 overflow-hidden'>
            <img src={image} alt="Blog Image" className="rounded-md w-full h-full object-cover" />
          </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default BlogCard;
