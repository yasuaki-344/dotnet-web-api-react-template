type ImageLinkProps = {
  href: string;
  src: string;
  className: string;
  alt: string;
};

export const ImageLink = (props: ImageLinkProps) => {
  const { href, src, className, alt } = props;

  return (
    <a href={href} target="_blank" rel="noopener noreferrer">
      <img src={src} className={className} alt={alt} />
    </a>
  );
};
