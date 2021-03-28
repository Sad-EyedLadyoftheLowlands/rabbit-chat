﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rabbit_chat.Models;

namespace rabbit_chat.Migrations
{
    [DbContext(typeof(RabbitChatContext))]
    [Migration("20210328161749_ActiumTesting")]
    partial class ActiumTesting
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("rabbit_chat.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MessageContent")
                        .HasColumnType("TEXT");

                    b.Property<int>("RabbitUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoomId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("TimeSent")
                        .HasColumnType("TEXT");

                    b.HasKey("MessageId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("rabbit_chat.Models.RabbitUser", b =>
                {
                    b.Property<int>("RabbitUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Alias")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RabbitUserId1")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RoomId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Token")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("RabbitUserId");

                    b.HasIndex("RabbitUserId1");

                    b.HasIndex("RoomId");

                    b.ToTable("RabbitUsers");
                });

            modelBuilder.Entity("rabbit_chat.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RoomName")
                        .HasColumnType("TEXT");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("rabbit_chat.Models.RabbitUser", b =>
                {
                    b.HasOne("rabbit_chat.Models.RabbitUser", null)
                        .WithMany("Friends")
                        .HasForeignKey("RabbitUserId1");

                    b.HasOne("rabbit_chat.Models.Room", null)
                        .WithMany("Users")
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("rabbit_chat.Models.RabbitUser", b =>
                {
                    b.Navigation("Friends");
                });

            modelBuilder.Entity("rabbit_chat.Models.Room", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}