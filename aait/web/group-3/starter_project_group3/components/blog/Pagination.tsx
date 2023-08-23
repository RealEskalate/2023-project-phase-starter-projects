import React from "react";

interface PaginationProps {
  currentPage: number;
  totalPages: number;
  onPageChange: (page: number) => void;
}

type Props = PaginationProps & React.HTMLProps<HTMLDivElement>;

const Pagination: React.FC<Props> = ({
  currentPage,
  totalPages,
  onPageChange,
  className, 
  ...rest 
}) => {
  
  return (
    <div className={`flex justify-center ${className}`} {...rest}>
      {Array.from({ length: totalPages }, (_, index) => (
        <button
          key={index}
          onClick={() => onPageChange(index + 1)}
          className={`px-2.5  mx-1 rounded-md ${
            currentPage === index + 1
              ? "bg-primary text-white"
              : "bg-gray-300 hover:bg-gray-400 text-gray-700"
          }`}
        >
          {index + 1}
        </button>
      ))}
    </div>
  );
};

export default Pagination;
