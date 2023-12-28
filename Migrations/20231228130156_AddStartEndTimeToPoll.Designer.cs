﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gcsharpRPC.Helpers;

#nullable disable

namespace gcsharpRPC.Migrations
{
    [DbContext(typeof(TrungContext))]
    [Migration("20231228130156_AddStartEndTimeToPoll")]
    partial class AddStartEndTimeToPoll
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.25");

            modelBuilder.Entity("gcsharpRPC.Models.Poll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CloseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PollGuid")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("gcsharpRPC.Models.PollOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PollId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PollId");

                    b.ToTable("PollOptions");
                });

            modelBuilder.Entity("gcsharpRPC.Models.UserVote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PollId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PollId");

                    b.ToTable("UserVotes");
                });

            modelBuilder.Entity("PollOptionUserVote", b =>
                {
                    b.Property<int>("OptionsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserVotesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OptionsId", "UserVotesId");

                    b.HasIndex("UserVotesId");

                    b.ToTable("PollOptionUserVote");
                });

            modelBuilder.Entity("gcsharpRPC.Models.PollOption", b =>
                {
                    b.HasOne("gcsharpRPC.Models.Poll", null)
                        .WithMany("Options")
                        .HasForeignKey("PollId");
                });

            modelBuilder.Entity("gcsharpRPC.Models.UserVote", b =>
                {
                    b.HasOne("gcsharpRPC.Models.Poll", "Poll")
                        .WithMany("UserVotes")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poll");
                });

            modelBuilder.Entity("PollOptionUserVote", b =>
                {
                    b.HasOne("gcsharpRPC.Models.PollOption", null)
                        .WithMany()
                        .HasForeignKey("OptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gcsharpRPC.Models.UserVote", null)
                        .WithMany()
                        .HasForeignKey("UserVotesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("gcsharpRPC.Models.Poll", b =>
                {
                    b.Navigation("Options");

                    b.Navigation("UserVotes");
                });
#pragma warning restore 612, 618
        }
    }
}
