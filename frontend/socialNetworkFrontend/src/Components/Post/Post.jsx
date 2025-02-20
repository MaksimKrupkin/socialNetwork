import React from 'react'
import styles from './Post.module.scss'
import image from '../../assets/avatar.jpg'
import post from '../../assets/post.jpg'
import { FaRegHeart } from "react-icons/fa";
import { BiComment } from "react-icons/bi";

export default function Post() {
    return (
        <div className={styles.wrapper}>
            <div className={styles.header}>
                <div className={styles.avatar}>
                    <img className={styles.image} src={image} alt=""/>
                    <div className={styles.userName}>Ramadanovna</div>
                </div>
                <div className={styles.createdAt}>11-11-2022</div>
            </div>
            <div className={styles.content}>
                <img className={styles.image} src={post} alt=""/>
                <div className={styles.text}></div>
            </div>
            <div className={styles.footer}>
                <div className={styles.wrap}>
                    <div className={styles.likes}>
                        <FaRegHeart size="25px"/>
                    </div>
                    <div className={styles.comments}>
                        <BiComment size="25px"/>
                    </div>
                </div>
                <div className={styles.likesCounter}>1174 users liked</div>
            </div>
        </div>
    )
}
