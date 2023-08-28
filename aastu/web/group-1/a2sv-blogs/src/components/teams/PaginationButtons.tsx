import React from "react";

interface PaginationButtonProps {
  currentPage: number;
  totalPages: number;
  setCurrentPage: (page: number) => void;
}

const PaginationButtons: React.FC<PaginationButtonProps> = ({
  currentPage,
  totalPages,
  setCurrentPage
}) => {

  const handlePageChange = (page: number) => {
    setCurrentPage(page);
  };

  return (
    <div className="flex justify-center space-x-2 font-poppins font-semibold text-sm leading-5 text-center pt-1 mt-4">
      {Array.from({ length: totalPages }, (_, index) => (
        <div 
          key={index + 1}
          className={ `${currentPage === index + 1 ? "bg-blue-700" : "bg-white"} w-10 h-10 ${
            currentPage === index + 1 ? "text-white" : "text-gray-800"
          } rounded-lg shadow-md px-2 py-2.5 cursor-pointer`}  
          onClick={() => handlePageChange(index + 1)}
        >
          {index + 1}
        </div>
      ))}
    </div>
  );
};

export default PaginationButtons;